using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace L1_2.lib
{
    public class Cone : ModelVisual3D
    {
        public Cone()
        {
            DrawCone();
        }
        private void DrawCone()
        {
            // Define the base radius and height of the cone
            double radius = 1.0;
            double height = 2.0;

            // Define the number of segments to create a smooth cone
            int segments = 32;

            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Add the center of base of the cone
            mesh.Positions.Add(new Point3D(0, 0, 0));

            // Add the apex of the cone
            mesh.Positions.Add(new Point3D(0, 0, height));

            // Add the vertices of the base of the cone
            for (int i = 0; i < segments; i++)
            {
                double angle = 2 * Math.PI * i / segments;
                double x = radius * Math.Cos(angle);
                double y = radius * Math.Sin(angle);
                mesh.Positions.Add(new Point3D(x, y, 0));
            }

            // Define the indices of the triangle fan for the base of the cone
            for (int i = 3; i <= segments; i++)
            {
                if (i == segments)
                {
                    mesh.TriangleIndices.Add(1);        // Apex of the cone
                    mesh.TriangleIndices.Add(2);  // Next vertex
                    mesh.TriangleIndices.Add(i - 1);    // Current vertex
                }
                else
                {
                    mesh.TriangleIndices.Add(1);        // Apex of the cone
                    mesh.TriangleIndices.Add(i);  // Next vertex
                    mesh.TriangleIndices.Add(i - 1);    // Current vertex
                }
            }

            // base
            for (int i = 3; i <= segments; i++)
            {
                if (i == segments)
                {
                    mesh.TriangleIndices.Add(0);        // base of the cone
                    mesh.TriangleIndices.Add(i - 1);    // Current vertex
                    mesh.TriangleIndices.Add(2);  // Next vertex
                }
                else
                {
                    mesh.TriangleIndices.Add(0);        // base of the cone
                    mesh.TriangleIndices.Add(i - 1);    // Current vertex
                    mesh.TriangleIndices.Add(i);  // Next vertex
                }
            }

            // Create a model from the mesh
            GeometryModel3D model = new GeometryModel3D(mesh, new DiffuseMaterial(Brushes.Red));

            // Create a model group and add the model to it
            Model3DGroup group = new Model3DGroup();
            group.Children.Add(model);

            Content = group;
        }
    }
}
