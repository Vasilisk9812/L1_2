using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace L1_2.lib
{
    public class Pyramid : ModelVisual3D
    {
        public Pyramid()
        {
            DrawPyramid();
        }
        private static GeometryModel3D AddFace(
                        Point3D point1,
                        Point3D point2,
                        Point3D point3,
                        Point3D point4,
                        Material material)
        {
            GeometryModel3D geometryModel3D = new()
            {
                Geometry = new MeshGeometry3D()
                {
                    Positions =
                    {
                        point1,
                        point2,
                        point3, //вершины первого треугольника
                        point3,
                        point4,
                        point1 //вершины второго треугольника
                    }
                },
                Material = material
            };
            return geometryModel3D;
        }
        private void DrawPyramid()
        {
            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();
            double moveX = 1; // Сдвиг по оси X влево
            double moveY = 1.5;  // Сдвиг по оси Y вверх

            Point3D p0 = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(2, 0, 0);
            Point3D p2 = new Point3D(2, 2, 0);
            Point3D p3 = new Point3D(0, 2, 0);
            Point3D p4 = new Point3D(0.5, 0.5, 2);
            Point3D p5 = new Point3D(1.5, 0.5, 2);
            Point3D p6 = new Point3D(0.5, 1.5, 2);
            Point3D p7 = new Point3D(1.5, 1.5, 2);

            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.Positions.Add(p4);
            mesh.Positions.Add(p5);
            mesh.Positions.Add(p6);
            mesh.Positions.Add(p7);

            Model3DGroup group = new Model3DGroup();
            // Добавление граней
            DiffuseMaterial material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront = AddFace(p1, p0, p3, p2, material);
            group.Children.Add(faceFront);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront1 = AddFace(p0, p1, p5, p4, material);
            group.Children.Add(faceFront1);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront2 = AddFace(p1, p2, p7, p5, material);
            group.Children.Add(faceFront2);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront3 = AddFace(p2, p3, p6, p7, material);
            group.Children.Add(faceFront3);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront4 = AddFace(p3, p0, p4, p6, material);
            group.Children.Add(faceFront4);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront5 = AddFace(p4, p5, p7, p6, material);
            group.Children.Add(faceFront5);

            Content = group;
        }
    }
}
