using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoLetra
{
    public class Origen
    {
        private float x, y, z;

        public Origen() 
        { 
            x = 0;
            y = 0;
            z = 0;
        }

        public Origen(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            set { z = value; }
            get { return z; }
        }
    }
}
