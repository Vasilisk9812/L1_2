using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace L1_2.lib
{
    public class Prism : ModelVisual3D
    {
        public Prism()
        {
            DrawPrism();
        }
        private static GeometryModel3D AddFace(
                        Point3D point1,
                        Point3D point2,
                        Point3D point3,
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
                        point3 //вершины первого треугольника
                    }
                },
                Material = material
            };
            return geometryModel3D;
        }
        private void DrawPrism()
        {
            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();
            double moveX = 1; // Сдвиг по оси X влево
            double moveY = 1.5;  // Сдвиг по оси Y вверх

            Point3D p0 = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(1, 0, 0);
            Point3D p2 = new Point3D(0.5, 1, 0);
            Point3D p3 = new Point3D(0, 0, 1);
            Point3D p4 = new Point3D(1, 0, 1);
            Point3D p5 = new Point3D(0.5, 1, 1);

            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.Positions.Add(p4);
            mesh.Positions.Add(p5);

            Model3DGroup group = new Model3DGroup();
            // Добавление граней
            // 1 Передняя
            DiffuseMaterial material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront = AddFace(p0, p1, p2, material);
            group.Children.Add(faceFront);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront1 = AddFace(p3, p5, p4, material);
            group.Children.Add(faceFront1);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront2 = AddFace(p0, p2, p3, material);
            group.Children.Add(faceFront2);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront3 = AddFace(p3, p2, p5, material);
            group.Children.Add(faceFront3);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront4 = AddFace(p5, p2, p1, material);
            group.Children.Add(faceFront4);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront5 = AddFace(p5, p1, p4, material);
            group.Children.Add(faceFront5);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront6 = AddFace(p4, p1, p0, material);
            group.Children.Add(faceFront6);

            // 1 Передняя
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront7 = AddFace(p3, p4, p0, material);
            group.Children.Add(faceFront7);

            Content = group;

            // Add the 3D scene to the viewport
            //MainViewport.Children.Add(visual);
        }
    }
}
