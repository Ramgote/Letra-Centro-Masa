using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace proyectoLetra
{
    public class Letra
    {
        private int vertexArrayObject;
        private int vertexbufferObject;
        private int elementBufferObject;

        private Color4 fondoColor;
        private Color4 letraColor;
        private Origen centro;

        private float[] vertices;
        private uint[] indices;

        public Letra()
        {
            centro = new Origen();
            this.fondoColor = new Color4(0, 255, 0, 0);
            this.letraColor = new Color4(0, 0, 0, 0);

            this.vertices = new float[]
            { 
                // Posiciones (x, y, z) y Colores (r, g, b)
                // Primer cubo (parte horizontal de la T)

                centro.X - 0.30f,  centro.Y + 0.20f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo frontal - Rojo
                centro.X + 0.30f,  centro.Y + 0.20f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.30f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.30f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo

                centro.X - 0.30f,  centro.Y + 0.20f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 4: Superior izquierdo frontal
                centro.X + 0.30f,  centro.Y + 0.20f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 5: Superior derecho frontal
                centro.X + 0.30f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 6: Inferior derecho frontal  
                centro.X - 0.30f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 7: Inferior izquierdo frontal

                // Primer cubo (parte horizontal de la T)

                centro.X - 0.10f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo atras - Rojo
                centro.X + 0.10f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.10f,  centro.Y - 0.60f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.10f,  centro.Y - 0.60f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo

                centro.X - 0.10f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo frontal - Rojo
                centro.X + 0.10f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.10f,  centro.Y - 0.60f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.10f,  centro.Y - 0.60f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo
                
            };

            this.indices = new uint[]
            {
                // Primer cubo
                
                0, 1, 2, 0, 2, 3,   // cara frontal
                4, 5, 6, 4, 6, 7,   // Cara trasera
                0, 3, 7, 0, 7, 4,   // Cara izquierda
                1, 5, 6, 1, 6, 2,   // Cara derecha
                4, 5, 1, 4, 1, 0,
                7, 6, 2, 7, 2, 3,

                // Segundo cubo
                8, 9, 10, 8, 10, 11, // Cara frontal
                12, 13, 14, 12, 14, 15, // Cara trasera
                8, 12, 15, 8, 15, 11,   // Cara izquierda
                9, 13, 14, 9, 14, 10,   // Cara derecha
                12, 13, 9, 12, 9, 8,
                15, 14, 10, 15, 10, 11
            };
        }

        public Letra(Origen centro, Color4 fondoColor, Color4 letraColor)
        {
            this.centro = centro;
            this.fondoColor = fondoColor;
            this.letraColor = letraColor;
            this.vertices = new float[]
            { 
                // Posiciones (x, y, z) y Colores (r, g, b)
                // Primer cubo (parte horizontal de la T)

                centro.X - 0.30f,  centro.Y + 0.20f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo frontal - Rojo
                centro.X + 0.30f,  centro.Y + 0.20f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.30f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.30f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo

                centro.X - 0.30f,  centro.Y + 0.20f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 4: Superior izquierdo frontal
                centro.X + 0.30f,  centro.Y + 0.20f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 5: Superior derecho frontal
                centro.X + 0.30f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 6: Inferior derecho frontal  
                centro.X - 0.30f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 7: Inferior izquierdo frontal

                // Primer cubo (parte horizontal de la T)

                centro.X - 0.10f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo atras - Rojo
                centro.X + 0.10f,  centro.Y + 0.00f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.10f,  centro.Y - 0.60f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.10f,  centro.Y - 0.60f,  centro.Z + 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo

                centro.X - 0.10f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 0: Superior izquierdo frontal - Rojo
                centro.X + 0.10f,  centro.Y + 0.00f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 1: Superior derecho frontal - Rojo
                centro.X + 0.10f,  centro.Y - 0.60f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 2: Inferior derecho frontal - Rojo      
                centro.X - 0.10f,  centro.Y - 0.60f,  centro.Z - 0.15f,  0.0f, 0.5f, 0.0f,  // Vértice 3: Inferior izquierdo frontal - Rojo
                
            };

            this.indices = new uint[]
            {
                // Primer cubo
                
                0, 1, 2, 0, 2, 3,   // cara frontal
                4, 5, 6, 4, 6, 7,   // Cara trasera
                0, 3, 7, 0, 7, 4,   // Cara izquierda
                1, 5, 6, 1, 6, 2,   // Cara derecha
                4, 5, 1, 4, 1, 0,
                7, 6, 2, 7, 2, 3,

                // Segundo cubo
                8, 9, 10, 8, 10, 11, // Cara frontal
                12, 13, 14, 12, 14, 15, // Cara trasera
                8, 12, 15, 8, 15, 11,   // Cara izquierda
                9, 13, 14, 9, 14, 10,   // Cara derecha
                12, 13, 9, 12, 9, 8,
                15, 14, 10, 15, 10, 11
            };

            InitializeBuffers();
        }

        public Origen Centro
        { 
            get { return centro; } 
            set { centro = value; }
        }

        private void InitializeBuffers()
        {

            vertexbufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexbufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

            elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(vertexArrayObject);
            GL.BindBuffer(BufferTarget.ArrayBuffer, vertexbufferObject);

            // Configura las posiciones
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // Configura los colores
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
            GL.BindVertexArray(0);
        }

        public void Dibujar()
        {
            GL.ClearColor(fondoColor);
            GL.BindVertexArray(vertexArrayObject);
            GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public void Dispose()
        {
            GL.DeleteBuffer(vertexbufferObject);
            GL.DeleteBuffer(elementBufferObject);
            GL.DeleteVertexArray(vertexArrayObject);
        }
    }
}
