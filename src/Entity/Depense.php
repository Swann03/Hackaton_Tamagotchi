<?php

namespace App\Entity;

use App\Repository\DepenseRepository;
use Doctrine\ORM\Mapping as ORM;
use App\Entity\Personnage; 
use ApiPlatform\Metadata\ApiResource;

#[ApiResource]
#[ORM\Entity(repositoryClass: DepenseRepository::class)]
class Depense
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 255)]
    private ?string $typeDepense = null;

    #[ORM\Column]
    private ?float $montant = null;

    #[ORM\Column(type: 'datetime')]
    private ?\DateTimeInterface $dateDepense = null;

    #[ORM\ManyToOne(inversedBy: 'depenses')]
    #[ORM\JoinColumn(nullable: false, onDelete: 'CASCADE')]
    private ?Personnage $personnage = null;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getTypeDepense(): ?string
    {
        return $this->typeDepense;
    }

    public function setTypeDepense(string $typeDepense): static
    {
        $this->typeDepense = $typeDepense;
        return $this;
    }

    public function getMontant(): ?float
    {
        return $this->montant;
    }

    public function setMontant(float $montant): static
    {
        $this->montant = $montant;
        return $this;
    }

    public function getDateDepense(): ?\DateTimeInterface
    {
        return $this->dateDepense;
    }

    public function setDateDepense(\DateTimeInterface $dateDepense): static
    {
        $this->dateDepense = $dateDepense;
        return $this;
    }

    public function getPersonnage(): ?Personnage
    {
        return $this->personnage;
    }

    public function setPersonnage(?Personnage $personnage): static
    {
        $this->personnage = $personnage;
        return $this;
    }
}
