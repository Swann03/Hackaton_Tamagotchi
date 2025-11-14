const button = document.getElementById('toggleTheme');
const body = document.body; 

const savedTheme= localStorage.getItem('theme'); 

if (savedTheme === 'dark'){
    body.classList.add('dark'); 
    button.textContent= 'Mode jour'; 
}

button.addEventListener('click', ()=>{
    body.classList.toggle('dark'); 

    if (body.classList.contains('dark')){
        button.textContent= 'Mode nuit';
        localStorage.setItem('theme', 'dark'); 
    }
    else{
      button.textContent= 'Mode jour'; 
      localStorage.setItem('theme', 'light');
    }
});