﻿using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace proyectoLetra
{
    // clase Escenario
    // clase Objeto
    // clase partes
    // clase Poligono
    // clase Poly(Lista de vertices)
    public class Game : GameWindow
    {
        private Origen origen;
        private Letra myLetra;
        private Letra l2;        

        private int shaderProgramObject;
        private Matrix4 model;
        private Matrix4 view;
        private Matrix4 projection;
        private float rotationAngle;
        private float rotationSpeed = 0.0f; // Velocidad de rotación

        public Game()
            : base(GameWindowSettings.Default, NativeWindowSettings.Default)
        {
            CenterWindow(new Vector2i(800, 640));
            origen = new Origen(0.3f, 0.5f, 0.0f);
            this.myLetra = new Letra(origen, new Color4(), new Color4());

            this.l2 = new Letra(new Origen(-0.3f, 0.03f, 0.0f), new Color4(), new Color4());
        }

        protected override void OnLoad()
        {
            //GL.ClearColor(new Color4(0.0f, 0.5f, 0.0f, 1f));

            string vertexShaderCode =
                @"
                 #version 330 core
                 layout (location=0) in vec3 aPosition;               
                 layout (location=1) in vec3 aColor;
                 out vec3 vertexColor;
                 uniform mat4 model;
                 uniform mat4 view;
                 uniform mat4 projection;
                 void main(){
                 gl_Position = projection * view * model * vec4(aPosition, 1.0);
                 vertexColor = aColor;
                 }";

            string pixelShaderCode =
                @"
                 #version 330 core
                 in vec3 vertexColor;
                 out vec4 pixelColor;
                 void main(){
                 pixelColor=vec4(vertexColor, 1.0);
                 }
                 ";

            int vertexShaderObject = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShaderObject, vertexShaderCode);
            GL.CompileShader(vertexShaderObject);

            int pixelShaderObject = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(pixelShaderObject, pixelShaderCode);
            GL.CompileShader(pixelShaderObject);

            shaderProgramObject = GL.CreateProgram();
            GL.AttachShader(shaderProgramObject, vertexShaderObject);
            GL.AttachShader(shaderProgramObject, pixelShaderObject);
            GL.LinkProgram(shaderProgramObject);
            GL.DetachShader(shaderProgramObject, vertexShaderObject);
            GL.DetachShader(shaderProgramObject, pixelShaderObject);
            GL.DeleteShader(vertexShaderObject);
            GL.DeleteShader(pixelShaderObject);

            // Configurar las matrices de transformación
            model = Matrix4.Identity;
            view = Matrix4.LookAt(new Vector3(0, 0, 3), Vector3.Zero, Vector3.UnitY);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Size.X / (float)Size.Y, 0.1f, 100.0f);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            base.OnLoad();
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            rotationAngle += rotationSpeed * (float)args.Time;
            model = Matrix4.CreateRotationY(rotationAngle) * Matrix4.CreateRotationX(rotationAngle / 2);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.UseProgram(shaderProgramObject);

            int modelLocation = GL.GetUniformLocation(shaderProgramObject, "model");
            int viewLocation = GL.GetUniformLocation(shaderProgramObject, "view");
            int projectionLocation = GL.GetUniformLocation(shaderProgramObject, "projection");

            GL.UniformMatrix4(modelLocation, false, ref model);
            GL.UniformMatrix4(viewLocation, false, ref view);
            GL.UniformMatrix4(projectionLocation, false, ref projection);

            // Dibujar los cubos
            myLetra.Dibujar();
            l2.Dibujar();
            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Up))
            {
                rotationSpeed += 0.1f;
            }

            if (KeyboardState.IsKeyDown(OpenTK.Windowing.GraphicsLibraryFramework.Keys.Down))
            {
                rotationSpeed = Math.Max(0.1f, rotationSpeed - 0.1f);
            }

            base.OnUpdateFrame(args);
        }

        protected override void OnUnload()
        {
            myLetra.Dispose();
            l2.Dispose();
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.UseProgram(0);
            GL.DeleteProgram(shaderProgramObject);
            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            GL.Viewport(0, 0, e.Width, e.Height);
            projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), e.Width / (float)e.Height, 0.1f, 100.0f);
            base.OnResize(e);
        }
    }
}
