<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20251112105351 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE depense ADD personnage_id INT NOT NULL');
        $this->addSql('ALTER TABLE depense ADD CONSTRAINT FK_340597575E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id) ON DELETE CASCADE');
        $this->addSql('CREATE INDEX IDX_340597575E315342 ON depense (personnage_id)');
        $this->addSql('ALTER TABLE evenement ADD personnage_id INT DEFAULT NULL');
        $this->addSql('ALTER TABLE evenement ADD CONSTRAINT FK_B26681E5E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id)');
        $this->addSql('CREATE INDEX IDX_B26681E5E315342 ON evenement (personnage_id)');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE depense DROP FOREIGN KEY FK_340597575E315342');
        $this->addSql('DROP INDEX IDX_340597575E315342 ON depense');
        $this->addSql('ALTER TABLE depense DROP personnage_id');
        $this->addSql('ALTER TABLE evenement DROP FOREIGN KEY FK_B26681E5E315342');
        $this->addSql('DROP INDEX IDX_B26681E5E315342 ON evenement');
        $this->addSql('ALTER TABLE evenement DROP personnage_id');
    }
}
