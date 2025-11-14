<?php

namespace App\Entity;

use App\Repository\PersonnageRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;
use ApiPlatform\Metadata\ApiResource;

#[ApiResource]
#[ORM\Entity(repositoryClass: PersonnageRepository::class)]
class Personnage
{
    #[ORM\Id]
    #[ORM\GeneratedValue]
    #[ORM\Column]
    private ?int $id = null;

    #[ORM\Column(length: 255)]
    private ?string $nom = null;

    #[ORM\Column(nullable: true)]
    private ?int $enfant = null;

    #[ORM\Column(nullable: true)]
    private ?float $argent = null;

    #[ORM\Column(type: 'datetime')]
    private ?\DateTimeInterface $dateCreation = null;

    /**
     * @var Collection<int, Depense>
     */
    #[ORM\OneToMany(
        targetEntity: Depense::class,
        mappedBy: 'personnage',
        cascade: ['persist', 'remove']
    )]
    private Collection $depenses;

    /**
     * @var Collection<int, Evenement>
     */
    #[ORM\OneToMany(
        targetEntity: Evenement::class,
        mappedBy: 'personnage',
        cascade: ['persist', 'remove']
    )]
    private Collection $evenements;

    #[ORM\Column(nullable: true)]
    private ?float $revenuHebdo = null;

    public function __construct()
    {
        $this->depenses = new ArrayCollection();
        $this->evenements = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getNom(): ?string
    {
        return $this->nom;
    }

    public function setNom(string $nom): static
    {
        $this->nom = $nom;
        return $this;
    }

    public function getEnfant(): ?int
    {
        return $this->enfant;
    }

    public function setEnfant(?int $enfant): static
    {
        $this->enfant = $enfant;
        return $this;
    }

    public function getArgent(): ?float
    {
        return $this->argent;
    }

    public function setArgent(?float $argent): static
    {
        $this->argent = $argent;
        return $this;
    }

    public function getDateCreation(): ?\DateTimeInterface
    {
        return $this->dateCreation;
    }

    public function setDateCreation(\DateTimeInterface $dateCreation): static
    {
        $this->dateCreation = $dateCreation;
        return $this;
    }

    /**
     * @return Collection<int, Depense>
     */
    public function getDepenses(): Collection
    {
        return $this->depenses;
    }

    public function addDepense(Depense $depense): static
    {
        if (!$this->depenses->contains($depense)) {
            $this->depenses->add($depense);
            $depense->setPersonnage($this);
        }

        return $this;
    }

    public function removeDepense(Depense $depense): static
    {
        if ($this->depenses->removeElement($depense)) {
            // set the owning side to null (unless already changed)
            if ($depense->getPersonnage() === $this) {
                $depense->setPersonnage(null);
            }
        }

        return $this;
    }

    /**
     * @return Collection<int, Evenement>
     */
    public function getEvenements(): Collection
    {
        return $this->evenements;
    }

    public function addEvenement(Evenement $evenement): static
    {
        if (!$this->evenements->contains($evenement)) {
            $this->evenements->add($evenement);
            $evenement->setPersonnage($this);
        }

        return $this;
    }

    public function removeEvenement(Evenement $evenement): static
    {
        if ($this->evenements->removeElement($evenement)) {
            // set the owning side to null (unless already changed)
            if ($evenement->getPersonnage() === $this) {
                $evenement->setPersonnage(null);
            }
        }

        return $this;
    }

    public function getRevenuHebdo(): ?float
    {
        return $this->revenuHebdo;
    }

    public function setRevenuHebdo(?float $revenuHebdo): static
    {
        $this->revenuHebdo = $revenuHebdo;

        return $this;
    }
}
