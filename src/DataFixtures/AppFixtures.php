<?php

namespace App\DataFixtures;

use App\Entity\Depense;
use App\Entity\Personnage;
use App\Entity\Evenement;
use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Persistence\ObjectManager;
use Faker\Factory;

class AppFixtures extends Fixture
{
    public function load(ObjectManager $manager): void
    {
        $faker = Factory::create('fr_FR');

        // LISTES D'ÉVÉNEMENTS
        $evenementsPositifs = [
            ["Mamie a envoyé 20€", "Un peu de soutien de la famille", 20],
            ["Prime exceptionnelle", "Belle surprise sur le compte", 50],
            ["Remboursement d'assurance", "Un trop-perçu est retourné", 30],
            ["Argent trouvé par terre", "Un petit billet inattendu", 10],
            ["Le voisin t’offre 15€", "Geste de gentillesse inattendu", 15],
        ];

        $evenementsNegatifs = [
            ["Chien chez le vétérinaire", "Urgence vétérinaire importante.", -100],
            ["Machine à laver cassée", "La réparation coûte cher…", -70],
            ["Facture surprise", "Une facture inattendue arrive.", -40],
            ["Achat impulsif", "Tu aurais pu t’en passer…", -25],
            ["Panne de voiture", "Réparation coûteuse au garage.", -80],
        ];

        // Création de 5 personnages
        for ($i = 0; $i < 5; $i++) {

            $p = new Personnage();
            $p->setNom($faker->lastName())
              ->setEnfant($faker->numberBetween(0, 3))
              ->setRevenuHebdo($faker->numberBetween(300, 750))
              ->setDateCreation(new \DateTime());

            $manager->persist($p);

            // NOURRITURE — 5€/repas × 3
            $repas = ['Petit-déjeuner', 'Déjeuner', 'Dîner'];
            foreach ($repas as $type) {
                $dep = new Depense();
                $dep->setTypeDepense("Nourriture - $type")
                    ->setMontant(5)
                    ->setDateDepense(new \DateTime())
                    ->setPersonnage($p);
                $manager->persist($dep);
            }

            // TRANSPORT — 1 par jour
            $typesTransport = [
                ['type' => 'Bus', 'prix' => 2],
                ['type' => 'Métro', 'prix' => 1.90],
                ['type' => 'Essence', 'prix' => $faker->numberBetween(5, 15)],
                ['type' => 'Uber', 'prix' => $faker->numberBetween(6, 12)],
            ];

            $t = $faker->randomElement($typesTransport);

            $depT = new Depense();
            $depT->setTypeDepense("Transport - " . $t['type'])
                 ->setMontant($t['prix'])
                 ->setDateDepense(new \DateTime())
                 ->setPersonnage($p);

            $manager->persist($depT);


            // EVENEMENTS ALÉATOIRES (0 à 3)
            $nbEvenements = rand(0, 3);

            for ($j = 0; $j < $nbEvenements; $j++) {

                // choisir positif ou négatif
                $isPositive = rand(0, 1) === 1;

                if ($isPositive) {
                    $ev = $faker->randomElement($evenementsPositifs);
                } else {
                    $ev = $faker->randomElement($evenementsNegatifs);
                }

                $e = new Evenement();
                $e->setNomEvenement($ev[0])
                  ->setDescription($ev[1])
                  ->setDateEvenement(new \DateTime())
                  ->setPersonnage($p);

                $manager->persist($e);
            }
        }

        $manager->flush();
    }
}
