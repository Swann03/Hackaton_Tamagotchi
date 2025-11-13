<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20251112123849 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE evenement DROP FOREIGN KEY FK_B26681E5E315342');
        $this->addSql('ALTER TABLE evenement ADD CONSTRAINT FK_B26681E5E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id) ON DELETE SET NULL');
        $this->addSql('ALTER TABLE personnage ADD revenu_mensuel DOUBLE PRECISION DEFAULT NULL');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('ALTER TABLE evenement DROP FOREIGN KEY FK_B26681E5E315342');
        $this->addSql('ALTER TABLE evenement ADD CONSTRAINT FK_B26681E5E315342 FOREIGN KEY (personnage_id) REFERENCES personnage (id)');
        $this->addSql('ALTER TABLE personnage DROP revenu_mensuel');
    }
}
