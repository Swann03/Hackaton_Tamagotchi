

const config = {
    type: Phaser.AUTO,
    width: 1080,
    height: 1920,
    scene: {
        preload: preload,
        create: create,
        update: update
    }
};





function preload(){
    this.load.image('fond','assets/fond.jpg');
}

function create(){
    this.add.image(400,300, 'fond');
}

function update(){
}

const game = new Phaser.Game(config);

