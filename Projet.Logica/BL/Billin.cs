using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetCore.Logica.BL
{
    public class Billin
    {
        public const double fivePercent = 0.05;
        public const double tenPercent = 0.1;
        public const double million = 1000000;
        public const double fivehundred = 500000;

        public Logica.Models.ViewModel.BillinVieModel getBilling(int reference, int quantity)
        {
            Logica.Models.ViewModel.BillinVieModel billinVieModel = new Models.ViewModel.BillinVieModel();

            List<Logica.Models.DB.Product> listaProduct = this.setProduct();

            foreach(Logica.Models.DB.Product product in listaProduct) {
                if (product.reference == reference) {
                    billinVieModel.description = product.description;
                    billinVieModel.subtotal = product.value * quantity;

                    if (billinVieModel.subtotal > fivehundred && billinVieModel.subtotal < million)
                    {
                        billinVieModel.discount = billinVieModel.subtotal * fivePercent;
                    }

                    if (billinVieModel.subtotal > million)
                    {
                        billinVieModel.discount = billinVieModel.subtotal * tenPercent;
                    }

                    billinVieModel.iva = billinVieModel.subtotal * 0.19;

                    billinVieModel.total = (billinVieModel.subtotal - billinVieModel.discount) + billinVieModel.iva;

                }
            }

            return billinVieModel;
        }

        private List<Logica.Models.DB.Product> setProduct()
        {
            List<Logica.Models.DB.Product> listaProduct = new List<Models.DB.Product>();

            Logica.Models.DB.Product product1 = new Models.DB.Product
            {
                reference = 1250,
                description = "MOUSE 3 BOTONES",
                value = 15500
            };

            listaProduct.Add(product1);

            Logica.Models.DB.Product product2 = new Models.DB.Product
            {
                reference = 1260,
                description = "IMPRESORA LASER",
                value = 678000
            };

            listaProduct.Add(product2);

            Logica.Models.DB.Product product3 = new Models.DB.Product
            {
                reference = 1270,
                description = "MEMORIA USB 20GB",
                value = 35000
            };

            listaProduct.Add(product3);

            Logica.Models.DB.Product product4 = new Models.DB.Product
            {
                reference = 1280,
                description = "DISCO DURO 500 GB",
                value = 18000
            };

            listaProduct.Add(product4);

            Logica.Models.DB.Product product5 = new Models.DB.Product
            {
                reference = 1290,
                description = "MONITOR 14 PULGADAS",
                value = 28000
            };

            listaProduct.Add(product5);

            Logica.Models.DB.Product product6 = new Models.DB.Product
            {
                reference = 1300,
                description = "UNIDAD DE DVD 32X",
                value = 98000
            };

            listaProduct.Add(product6);

            Logica.Models.DB.Product product7 = new Models.DB.Product
            {
                reference = 1310,
                description = "TECLADO USB",
                value = 22000 
            };

            listaProduct.Add(product7);

            Logica.Models.DB.Product product8 = new Models.DB.Product
            {
                reference = 1320,
                description = "PORTATIL SAMSUNG RV411",
                value = 1450000
            };

            listaProduct.Add(product8);

            Logica.Models.DB.Product product9 = new Models.DB.Product
            {
                reference = 1330,
                description = "MEMORIA RAM 4G",
                value = 62500
            };

            listaProduct.Add(product9);

            Logica.Models.DB.Product product10 = new Models.DB.Product
            {
                reference = 1340,
                description = "PARLANTES",
                value = 189000
            };

            listaProduct.Add(product10);

            Logica.Models.DB.Product product11 = new Models.DB.Product
            {
                reference = 1350,
                description = "SUBWOOFER 5.1 CANALES",
                value = 124000
            };

            listaProduct.Add(product11);

            Logica.Models.DB.Product product12 = new Models.DB.Product
            {
                reference = 1360,
                description = "VIDEO CAMARA",
                value = 58000
            };

            listaProduct.Add(product12);

            Logica.Models.DB.Product product13 = new Models.DB.Product
            {
                reference = 1370,
                description = "PAD MAUSE GEL",
                value = 12000
            };

            listaProduct.Add(product13);

            Logica.Models.DB.Product product14 = new Models.DB.Product
            {
                reference = 1380,
                description = "AUDIFONOS",
                value = 9000
            };

            listaProduct.Add(product14);

            Logica.Models.DB.Product product15 = new Models.DB.Product
            {
                reference = 1390,
                description = "DISCO MDURO EXTERNO 250 GB",
                value = 170000
            };

            listaProduct.Add(product15);

            Logica.Models.DB.Product product16 = new Models.DB.Product
            {
                reference = 1400,
                description = "TABLET PC SMART",
                value = 475000
            };

            listaProduct.Add(product16);

            return listaProduct;
        }
    }
}
