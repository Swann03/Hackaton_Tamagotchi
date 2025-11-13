<?php

namespace App\DataFixtures;

use App\Entity\Personnage;
use App\Entity\Depense;
use App\Entity\Evenement;
use Doctrine\Bundle\FixturesBundle\Fixture;
use Doctrine\Persistence\ObjectManager;
use Faker\Factory;

class AppFixtures extends Fixture
{
    public function load(ObjectManager $manager): void
    {
        $faker = Factory::create('fr_FR');

        $personnages = [];
        for ($i = 0; $i < 5; $i++) {
            $p = new Personnage();
            $p->setNom($faker->firstName());
            $p->setRevenuMensuel($faker->numberBetween(800, 3000));
            $p->setDateCreation($faker->dateTimeBetween('-1 year', 'now'));
            $p->setEnfant($faker->numberBetween(0, 5));
            
            $manager->persist($p);
            $personnages[] = $p;
        }

        for ($i = 0; $i < 20; $i++) {
            $d = new Depense();
            $d->setTypeDepense($faker->randomElement(['Loyer', 'Nourriture', 'Transport']));
            $d->setMontant($faker->randomFloat(2, 10, 600));
            $d->setDateDepense($faker->dateTimeBetween('-3 months', 'now'));
            $d->setPersonnage($faker->randomElement($personnages));
            $manager->persist($d);
        }

        for ($i = 0; $i < 10; $i++) {
            $e = new Evenement();
            $e->setNomEvenement($faker->sentence(3));
            $e->setDescription($faker->sentence(20));
            $e->setPersonnage($faker->randomElement($personnages));
            $manager->persist($e);
        }

        $manager->flush();
    }
}
