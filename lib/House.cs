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
    public class House : ModelVisual3D
    {
        public House()
        {
            DrawHouse();
        }
        private static GeometryModel3D AddFace1(
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
        private void DrawHouse()
        {
            // Create a new mesh geometry
            MeshGeometry3D mesh = new MeshGeometry3D();
            double moveX = 1; // Сдвиг по оси X влево
            double moveY = 1.5;  // Сдвиг по оси Y вверх

            Point3D p0 = new Point3D(0, 0, 0);
            Point3D p1 = new Point3D(2, 0, 0);
            Point3D p2 = new Point3D(0, 2, 0);
            Point3D p3 = new Point3D(2, 2, 0);
            Point3D p4 = new Point3D(0, 0, 2);
            Point3D p5 = new Point3D(2, 0, 2);
            Point3D p6 = new Point3D(0, 2, 2);
            Point3D p7 = new Point3D(2, 2, 2);
            //Крыша
            Point3D p8 = new Point3D(-0.5, -0.5, 2);
            Point3D p9 = new Point3D(2.5, -0.5, 2);
            Point3D p10 = new Point3D(2.5, 2.5, 2);
            Point3D p11 = new Point3D(-0.5, 2.5, 2);
            Point3D p12 = new Point3D(1, 2.5, 3.5);
            Point3D p13 = new Point3D(1, -0.5, 3.5);
            //Дверь
            Point3D p14 = new Point3D(0.5, -0.005, 0);
            Point3D p15 = new Point3D(0.9, -0.005, 0);
            Point3D p16 = new Point3D(0.5, -0.005, 0.9);
            Point3D p17 = new Point3D(0.9, -0.005, 0.9);
            //Окно
            Point3D p18 = new Point3D(1.1, -0.005, 0.9);
            Point3D p19 = new Point3D(1.8, -0.005, 0.9);
            Point3D p20 = new Point3D(1.8, -0.005, 1.6);
            Point3D p21 = new Point3D(1.1, -0.005, 1.6);

            mesh.Positions.Add(p0);
            mesh.Positions.Add(p1);
            mesh.Positions.Add(p2);
            mesh.Positions.Add(p3);
            mesh.Positions.Add(p4);
            mesh.Positions.Add(p5);
            mesh.Positions.Add(p6);
            mesh.Positions.Add(p7);
            mesh.Positions.Add(p8);
            mesh.Positions.Add(p9);
            mesh.Positions.Add(p10);
            mesh.Positions.Add(p11);
            mesh.Positions.Add(p12);
            mesh.Positions.Add(p13);
            mesh.Positions.Add(p14);
            mesh.Positions.Add(p15);
            mesh.Positions.Add(p16);
            mesh.Positions.Add(p17);
            mesh.Positions.Add(p18);
            mesh.Positions.Add(p19);
            mesh.Positions.Add(p20);
            mesh.Positions.Add(p21);

            Model3DGroup group = new Model3DGroup();
            // Добавление граней
            // 1 Стены
            DiffuseMaterial material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront = AddFace(p0, p2, p3, p1, material);
            group.Children.Add(faceFront);

            material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront1 = AddFace(p0, p1, p5, p4, material);
            group.Children.Add(faceFront1);

            material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront2 = AddFace(p1, p3, p7, p5, material);
            group.Children.Add(faceFront2);

            material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront3 = AddFace(p3, p2, p6, p7, material);
            group.Children.Add(faceFront3);

            material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront4 = AddFace(p2, p0, p4, p6, material);
            group.Children.Add(faceFront4);

            material = new DiffuseMaterial(Brushes.White);
            GeometryModel3D faceFront5 = AddFace(p4, p5, p7, p6, material);
            group.Children.Add(faceFront5);

            // 2 Крыша
            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront6 = AddFace1(p8, p9, p13, material);
            group.Children.Add(faceFront6);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront7 = AddFace1(p10, p11, p12, material);
            group.Children.Add(faceFront7);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront8 = AddFace(p12, p13, p9, p10, material);
            group.Children.Add(faceFront8);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront9 = AddFace(p11, p8, p13, p12, material);
            group.Children.Add(faceFront9);

            material = new DiffuseMaterial(Brushes.Red);
            GeometryModel3D faceFront10 = AddFace(p8, p11, p10, p9, material);
            group.Children.Add(faceFront10);

            // 3 Дверь
            material = new DiffuseMaterial(Brushes.Brown);
            GeometryModel3D faceFront11 = AddFace(p14, p15, p17, p16, material);
            group.Children.Add(faceFront11);

            // 4 Окно
            material = new DiffuseMaterial(Brushes.Aqua);
            GeometryModel3D faceFront12 = AddFace(p18, p19, p20, p21, material);
            group.Children.Add(faceFront12);

            Content = group;

        }
    }
}
