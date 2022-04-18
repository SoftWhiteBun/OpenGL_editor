
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpGL;
using SharpGL.SceneGraph.Assets;

namespace Lr4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        float rottr = 0;  //угол поворота треугоьника
        float rottrs = 0;
        float rottrsss = 0;
        bool tetra = false;
        bool line = false;
        bool tria = false;
        bool backgr = false;
        bool rect = false;
        bool col = false;
        bool thick = false;
        bool ang5 = false;
        bool ang6 = false;
        bool linetype = false;
        bool linetype1 = false;
        bool rot = false;
        float sc = 0; bool scale = false;

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            OpenGL gl = openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            gl.Color(1.0f, 0.0f, 0.0f);
            if (col)
            {
                float r = (float)numericUpDownR.Value;
                float g = (float)numericUpDownG.Value;
                float b = (float)numericUpDownB.Value;
                gl.Color(r, g, b);
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            }

           

            if (tetra)
            {
                 gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(-1.5f, 0.0f, -6.0f);//передвигаем начало координат

                if (rot)
                {
                    gl.Rotate(rottr, 0.0f, 1.0f, 0.0f);
                    gl.Rotate(rottrs, 1.0f, 0.0f, 0.0f);
                    gl.Rotate(rottrsss, 0.0f, 0.0f, 1.0f);
                }

                if (radioButtonFull.Checked == true)
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                else
                {
                    if (radioButtonLine.Checked == true)
                        gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                    else
                    {
                        if (radioButtonPoint.Checked == true)
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);                      
                    }
                }
                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                if (linetype1)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }


                gl.Begin(OpenGL.GL_TRIANGLES);

                gl.Color(1.0f, 0.0f, 0.0f);  //front
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);

                gl.Color(1.0f, 0.0f, 0.0f);  //right
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);

               gl.Color(1.0f, 0.0f, 0.0f);   //back
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f); 

                gl.Color(1.0f, 0.0f, 0.0f);   //left
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.End();
                gl.Flush();
                rottr += 3.0f;
                rottrs += 4.0f;
                rottrsss += 5.0f;
                
            }

            gl.LineWidth(1);       // ширину линии
            if (thick)
            {
                float th = (float)numericUpDownThick.Value;
                gl.LineWidth(th);
            }
            
            if (line)
            {
                gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();

                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                gl.Translate(-1.5f, 0.0f, -6.0f);//передвигаем начало координат
              //  gl.LineWidth(1);       // ширину линии
                                       // устанавливаем 1
                float x1 = (float)numericUpDownlX1.Value;
                float x2 = (float)numericUpDownlX2.Value;
                float y1 = (float)numericUpDownlY1.Value;
                float y2 = (float)numericUpDownlY2.Value;
                float z1 = (float)numericUpDownlZ1.Value;
                float z2 = (float)numericUpDownlZ2.Value;

                gl.Begin(OpenGL.GL_LINES);
          //      gl.Color(1.0f, 0.0f, 0.0f);     // красный цвет
                gl.Vertex(x1, y1, z1);
                gl.Vertex(x2, y2, z2);
                gl.End();
                gl.Flush();
            }

            if (tria)
            {
                gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(-1.5f, 0.0f, -6.0f);

                float x1 = (float)numericUpDownX1.Value;
                float x2 = (float)numericUpDownX2.Value;
                float x3 = (float)numericUpDownX3.Value;
                float y1 = (float)numericUpDownY1.Value;
                float y2 = (float)numericUpDownY2.Value;
                float y3 = (float)numericUpDownY3.Value;
                float z1 = (float)numericUpDownZ1.Value;
                float z2 = (float)numericUpDownZ2.Value;
                float z3 = (float)numericUpDownZ3.Value;

                if (radioButtonFull.Checked == true)
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                else
                {
                    if (radioButtonLine.Checked == true)
                        gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                    else
                    {
                        if (radioButtonPoint.Checked == true)
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);

                    }
                }
                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                if (linetype1)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }

                gl.Begin(OpenGL.GL_TRIANGLES);
             //   gl.Color(1.0f, 0.0f, 0.0f);  //front
                gl.Vertex(x1, y1, z1);
                gl.Vertex(x2, y2, z2);
                gl.Vertex(x3, y3, z3);
                gl.End();
                gl.Flush();
            }

            if (backgr)
            {
                float a = (float)numericUpDownR.Value;
                float b = (float)numericUpDownG.Value;
                float c = (float)numericUpDownB.Value;

                gl.ClearColor(a, b, c, 1);
                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT);
            }

            if (rect)
            {
                gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(-1.5f, 0.0f, -6.0f);

               

                if (radioButtonFull.Checked == true)
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                else
                {
                    if (radioButtonLine.Checked == true)
                        gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                    else
                    {
                        if (radioButtonPoint.Checked == true)
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);

                    }
                }
                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                if (linetype1)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }

                gl.Begin(OpenGL.GL_POLYGON);

                float x1 = (float)numericUpDownSX1.Value;
                float x2 = (float)numericUpDownSX2.Value;
                float x3 = (float)numericUpDownSX3.Value;
                float x4 = (float)numericUpDownSX4.Value;
                float y1 = (float)numericUpDownSY1.Value;
                float y2 = (float)numericUpDownSY2.Value;
                float y3 = (float)numericUpDownSY3.Value;
                float y4 = (float)numericUpDownSY4.Value;
                float z1 = (float)numericUpDownSZ1.Value;
                float z2 = (float)numericUpDownSZ2.Value;
                float z3 = (float)numericUpDownSZ3.Value;
                float z4 = (float)numericUpDownSZ4.Value;

            //    gl.Color(1.0f, 0.0f, 0.0f);  //front
                gl.Vertex(x1, y1, z1);
                gl.Vertex(x2, y2, z2);
                gl.Vertex(x3, y3, z3);
                gl.Vertex(x4,y4, z4);
                gl.End();
                gl.Flush();
            }

            if (ang5)
            {
                gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(-1.5f, 0.0f, -6.0f);


                float x1 = (float)numericUpDown5X1.Value;
                float x2 = (float)numericUpDown5X2.Value;
                float x3 = (float)numericUpDown5X3.Value;
                float x4 = (float)numericUpDown5X4.Value;
                float x5 = (float)numericUpDown5X5.Value;
                float y1 = (float)numericUpDown5Y1.Value;
                float y2 = (float)numericUpDown5Y2.Value;
                float y3 = (float)numericUpDown5Y3.Value;
                float y4 = (float)numericUpDown5Y4.Value;
                float y5 = (float)numericUpDown5Y5.Value;
                float z1 = (float)numericUpDown5Z1.Value;
                float z2 = (float)numericUpDown5Z2.Value;
                float z3 = (float)numericUpDown5Z3.Value;
                float z4 = (float)numericUpDown5Z4.Value;
                float z5 = (float)numericUpDown5Z5.Value;

                
                if (radioButtonFull.Checked == true)
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                else
                {
                    if (radioButtonLine.Checked == true)
                        gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                    else
                    {
                        if (radioButtonPoint.Checked == true)
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);

                    }
                }

                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                if (linetype1)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(x1, y1, z1);
                gl.Vertex(x2, y2, z2);
                gl.Vertex(x3, y3, z3);
                gl.Vertex(x4, y4, z4);
                gl.Vertex(x5, y5, z5);
                gl.End();
                gl.Flush();
            }

            if (ang6)
            {
                gl = openGLControl1.OpenGL;

                gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
                gl.LoadIdentity();
                gl.Translate(-1.5f, 0.0f, -6.0f);


                float x1 = (float)numericUpDown6X1.Value;
                float x2 = (float)numericUpDown6X2.Value;
                float x3 = (float)numericUpDown6X3.Value;
                float x4 = (float)numericUpDown6X4.Value;
                float x5 = (float)numericUpDown6X5.Value;
                float x6 = (float)numericUpDown6X6.Value;
                float y1 = (float)numericUpDown6Y1.Value;
                float y2 = (float)numericUpDown6Y2.Value;
                float y3 = (float)numericUpDown6Y3.Value;
                float y4 = (float)numericUpDown6Y4.Value;
                float y5 = (float)numericUpDown6Y5.Value;
                float y6 = (float)numericUpDown6Y6.Value;
                float z1 = (float)numericUpDown6Z1.Value;
                float z2 = (float)numericUpDown6Z2.Value;
                float z3 = (float)numericUpDown6Z3.Value;
                float z4 = (float)numericUpDown6Z4.Value;
                float z5 = (float)numericUpDown6Z5.Value;
                float z6 = (float)numericUpDown6Z6.Value;

                if (radioButtonFull.Checked == true)
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_FILL);
                else
                {
                    if (radioButtonLine.Checked == true)
                        gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                    else
                    {
                        if (radioButtonPoint.Checked == true)
                            gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_POINT);

                    }
                }

                if (linetype)
                {
                    gl.Enable(OpenGL.GL_LINE_STIPPLE);
                    gl.LineStipple(2, 250);
                }
                if (linetype1)
                {
                    gl.PolygonMode(OpenGL.GL_FRONT_AND_BACK, OpenGL.GL_LINE);
                }

                gl.Begin(OpenGL.GL_POLYGON);
                gl.Vertex(x1, y1, z1);
                gl.Vertex(x2, y2, z2);
                gl.Vertex(x3, y3, z3);
                gl.Vertex(x4, y4, z4);
                gl.Vertex(x5, y5, z5);
                gl.Vertex(x6, y6, z6);
                gl.End();
                gl.Flush();
            }
        }

        private void buttonline_Click(object sender, EventArgs e)
        {
            if (!line)
                line = true;
            else
                line = false;
        }

        private void buttonTetrahedron_Click(object sender, EventArgs e)
        {
            if (!tetra)
                tetra = true;
            else
                tetra = false;
        }

        private void buttonTriangle_Click(object sender, EventArgs e)
        {
            if (!tria)
                tria = true;
            else
                tria = false;
        }

        private void buttonBackground_Click(object sender, EventArgs e)
        {
            if (!backgr)
                backgr = true;
            else
                backgr = false;

        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            if (!rect)
                rect = true;
            else
                rect = false;
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            backgr = false;
            if (!col)
                col = true;
            else
                col = false;

        }

        private void numericUpDownSZ2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {

        }

        private void buttonThickness_Click(object sender, EventArgs e)
        {
            thick = true;
        }

        private void фигурыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBoxFigure.Visible == true)
                groupBoxFigure.Visible = false;
            else groupBoxFigure.Visible = true;
        }

        private void инструментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (groupBoxTools.Visible == true)
                groupBoxTools.Visible = false;
            else groupBoxTools.Visible = true;
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            if (!scale)
            {
                sc = (float)numericUpDownScale.Value;
                scale = true;
            }
            else scale = false;
            
            
        }

        private void button5Angle_Click(object sender, EventArgs e)
        {
            if (!ang5)
                ang5 = true;
            else
                ang5 = false;
        }

        private void button6Angle_Click(object sender, EventArgs e)
        {
            if (!ang6)
                ang6 = true;
            else
                ang6 = false;
        }

        private void radioButtonDotted_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDotted.Checked == true)
                linetype = true;
            else linetype = false;
        }

        private void radioButtonSolid_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSolid.Checked == true)
            {
                linetype = false;
                linetype1 = true;
            }
        }

        private void buttonRot_Click(object sender, EventArgs e)
        {
            if (!rot)
                rot = true;
            else rot = false;
        }
    }
}
