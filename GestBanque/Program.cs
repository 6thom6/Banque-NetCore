﻿using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start Exo!");

            Personne p1 = new Personne();
            p1.Prenom = "Zaza";
            p1.Nom = "Vanderquack";
            p1.DateNaiss = new DateTime(2010, 01, 06);

            Courant c1 = new Courant();
            c1.Numero = "BE00001";
            c1.Titulaire = p1;
            c1.LigneDeCredit = 100;
            c1.Depot(500);
            AfficherCompte(c1);

            c1.Retrait(250);
            AfficherCompte(c1);

            c1.Retrait(300);
            c1.Retrait(300);
            AfficherCompte(c1);

            Epargne e1 = new Epargne();
            e1.Numero = "BE00003";
            e1.Titulaire = p1;
            e1.Depot(200);

            AfficherCompte(e1);

            //--------------------------------------------------
            Banque banque = new Banque();
            banque.Nom = "ConfitBanque";
            banque.Ajouter(c1);

            Courant c2 = new Courant()
            {
                Numero = "BE00002",
                Titulaire = p1,
                LigneDeCredit = 0
            };
            c2.Depot(50);

            banque.Ajouter(c2);

            Courant cZaza01 = banque["BE00001"];
            AfficherCompte(cZaza01);

            Console.WriteLine("Avoir des comptes de {0} : {1}", p1.Nom, banque.AvoirDesComptes(p1));
        }

        private static void AfficherCompte(Compte c)
        {
            Console.WriteLine($"{c.Numero} {c.Solde} - {c.Titulaire.NomComplet} ");
            Console.WriteLine();
        }
    }
}
