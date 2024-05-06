using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace L1_2.lib
{
    public class Toroid : ModelVisual3D
    {
        public Toroid()
        {
            DrawToroid();
        }
        private void DrawToroid()
        {
            // Define the major and minor radii of the torus
            double majorRadius = 2.0;
            double minorRadius = 0.5;

            // Define the number of segments for generating the torus
            int majorSegments = 24;
            int minorSegments = 12;

            // Create a list to hold the vertices
            List<Point3D> vertices = new List<Point3D>();

            // Generate the vertices of the torus
            for (int i = 0; i < majorSegments; i++)
            {
                double majorAngle = 2 * Math.PI * i / majorSegments;

                for (int j = 0; j < minorSegments; j++)
                {
                    double minorAngle = 2 * Math.PI * j / minorSegments;

                    double x = (majorRadius + minorRadius * Math.Cos(minorAngle)) * Math.Cos(majorAngle);
                    double y = (majorRadius + minorRadius * Math.Cos(minorAngle)) * Math.Sin(majorAngle);
                    double z = minorRadius * Math.Sin(minorAngle);

                    vertices.Add(new Point3D(x, y, z));
                }
            }

            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();

            // Add the vertices to the mesh
            foreach (var vertex in vertices)
            {
                mesh.Positions.Add(vertex);
            }

            // Define the indices of the triangles for the torus
            for (int i = 0; i < majorSegments; i++)
            {
                for (int j = 0; j < minorSegments; j++)
                {
                    int currentIndex = i * minorSegments + j;
                    int nextIndex = (i * minorSegments + (j + 1) % minorSegments) % vertices.Count;
                    int belowIndex = ((i + 1) % majorSegments) * minorSegments + j;
                    int nextBelowIndex = ((i + 1) % majorSegments) * minorSegments + (j + 1) % minorSegments;

                    mesh.TriangleIndices.Add(currentIndex);
                    mesh.TriangleIndices.Add(belowIndex);
                    mesh.TriangleIndices.Add(nextIndex);

                    mesh.TriangleIndices.Add(nextIndex);
                    mesh.TriangleIndices.Add(belowIndex);
                    mesh.TriangleIndices.Add(nextBelowIndex);
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
