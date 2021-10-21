using System;

namespace Labo_Tour_de_Zork_Combat_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quand on intègre les classes, on prend les stats et elles deviennent des attributs
            // de la classe!

            // Stats pour Sergent Ebellius
            string nomSergent = "Sergent Ebellius";
            int pvSergent = 20;
            int armureSergent = 20;
            int agiliteSergent = 12;
            int dommageSergent = 7;
            int initiativeSergent = 0;

            // Stats pour Pustus le Vile
            string nomPustus = "Pustus le Vile";
            int pvPustus = 30;
            int armurePustus = 10;
            int agilitePustus = 8;
            int dommagePustus = 11;
            int initiativePustus = 0;

            // Le combat sera fini quand un des deux personnage arrive à 0 pv
            while (pvSergent > 0 && pvPustus > 0)
            {
                // Celui qui a l'initiative la plus haute frappe en prmier
                // Si l'autre n'est pas mort, il réplique avec ses dommages
                // Quand l'initiative est égales, les 2 dommages sont assignés sans exception
                initiativeSergent = GenererInitiative(agiliteSergent);
                initiativePustus = GenererInitiative(agilitePustus);
                if (initiativeSergent > initiativePustus)
                {
                    // Il faut vérifier l'armure avant d'enlever des points de vie
                    // En enlevant toujours les dégât à l'armure on fini par avoir une nombre négatif
                    //
                    // Quand on a un nombre négatif, on enlève ce nombre aux points de vie et on remet l'armure à 0 
                    // pour ne pas fausser les calculs subséquents
                    //
                    // Il serait possible de gérer l'assignation des dommages avec une méthode, mais je vous épargne
                    // le mal de tête
                    armurePustus -= GenererDommages(dommageSergent);
                    if (armurePustus < 0)
                    {
                        // la variable d'armure du personnage contient un nombre négatif
                        // il représente le nombre de dommages ayant dépassé l'armure
                        // donc on addition le nombre négatif aux points de vie pour avoir un 
                        // résultat cohérent
                        // ex: armurePustus -3 & pvPustus 30 
                        //     en faisant pvPustus += armurePustus on a 30 + -3
                        pvPustus += armurePustus;
                        // Il ne faut pas oublier de remttre l'armure à 0, sinon on a encore les dommages du tour précédent
                        armurePustus = 0;
                    }
                    // On assigne les dégâts au premier personnage seulement si le 2ème est encore vivant
                    if (pvPustus > 0)
                    {
                        armureSergent -= GenererDommages(dommagePustus);
                        if (armureSergent < 0)
                        {
                            pvSergent += armureSergent;
                            armureSergent = 0;
                        }
                    }
                }
                else if (initiativePustus > initiativeSergent)
                {
                    // On répète le processus mais dans un ordre différent
                    armureSergent -= GenererDommages(dommagePustus);
                    if (armureSergent < 0)
                    {
                        pvSergent += armureSergent;
                        armureSergent = 0;
                    }
                    if (pvSergent > 0)
                    {
                        armurePustus -= GenererDommages(dommageSergent);
                        if (armurePustus < 0)
                        {
                            pvPustus += armurePustus;
                            armurePustus = 0;
                        }
                    }
                }
                else
                {
                    // Si les 2 personnages se frappent simultanément c'est encore le même processus mais 
                    // les dommages sont assignés même si les points de vie du premier tombent sous 0
                    armureSergent -= GenererDommages(dommagePustus);
                    if (armureSergent < 0)
                    {
                        pvSergent += armureSergent;
                        armureSergent = 0;
                    }
                    armurePustus -= GenererDommages(dommageSergent);
                    if (armurePustus < 0)
                    {
                        pvPustus += armurePustus;
                        armurePustus = 0;
                    }
                }

                // Afficher les stats défensive de chaque personnage à la fin du tour
                Console.WriteLine($"{nomPustus} armure: {armurePustus}  pv: {pvPustus}");
                Console.WriteLine($"{nomSergent} armure: {armureSergent} pv: {pvSergent}");
                Console.WriteLine("Appuyer sur une touche pour continuer");
                Console.ReadKey();
                Console.Clear();
            }

            // Fin du combat, on affiche le résultat
            Console.Clear();
            if (pvSergent <= 0 && pvPustus > 0)
            {
                Console.WriteLine($"{nomSergent} est mort, {nomPustus} a gagné");
            }
            else if (pvPustus <= 0 && pvSergent > 0)
            {
                Console.WriteLine($"{nomPustus} est mort, {nomSergent} a gagné");
            }
            else
            {
                Console.WriteLine($"Les deux combatants sont morts!");
            }
            Console.ReadKey();
        }

        /**
        * Génère une initiative aléatoire en utilisant l'agilité du personnage
        * 
        * @param agilite un nombre entier représentant l'agilité de base du personnage
        * @return un nombre aléatoire modifié par l'agilité
        */
        static int GenererInitiative(int agilite)
        {

        }

        /**
        * Selon un pourcentage, calcule les dommages causés par un personnage en se basant sur la statistique dommage du personnage
        * 
        * Comme il n'est pas possible de multiplier un int par un double,
        * on utilise une multiplication par 3 puis division par deux pour les coups critiques
        *
        * @param dommage les dommages de base du personnage
        * @return les dommages finaux causés par le personnage
        */
        static int GenererDommages(int dommage)
        {

        }
    }
}
