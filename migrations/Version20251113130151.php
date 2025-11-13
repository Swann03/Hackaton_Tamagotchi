<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20251113130151 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('CREATE TABLE depense (id INT AUTO_INCREMENT NOT NULL, personnage_id INT NOT NULL, type_depense VARCHAR(255) NOT NULL, montant DOUBLE PRECISION NOT NULL, date_depense DATETIME NOT NULL, INDEX IDX_340597575E315342 (personnage_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE evenement (id INT AUTO_INCREMENT NOT NULL, personnage_id INT DEFAULT NULL, nom_evenement VARCHAR(255) NOT NULL, date_evenement DATETIME NOT NULL, description LONGTEXT NOT NULL, INDEX IDX_B26681E5E315342 (personnage_id), PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE personnage (id INT AUTO_INCREMENT NOT NULL, nom VARCHAR(255) NOT NULL, enfant INT DEFAULT NULL, argent DOUBLE PRECISION DEFAULT NULL, date_creation DATETIME NOT NULL, revenu_hebdo DOUBLE PRECISION DEFAULT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('ALTER TABLE depense ADD CONSTRAINT FK_340597575E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id) ON DELETE CASCADE');
        $this->addSql('ALTER TABLE evenement ADD CONSTRAINT FK_B26681E5E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id) ON DELETE SET NULL');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE depense DROP FOREIGN KEY FK_340597575E315342');
        $this->addSql('ALTER TABLE evenement DROP FOREIGN KEY FK_B26681E5E315342');
        $this->addSql('DROP TABLE depense');
        $this->addSql('DROP TABLE evenement');
        $this->addSql('DROP TABLE personnage');
    }
}
