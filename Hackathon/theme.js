const button = document.getElementById('toggleTheme');
const body = document.body; 

const savedTheme= localStorage.getItem('theme'); 

if (savedTheme === 'dark'){
    body.classList.add('dark'); 
    button.textContent= 'Mode gold'; 
}

button.addEventListener('click', ()=>{
    body.classList.toggle('dark'); 

    if (body.classList.contains('dark')){
        button.textContent= 'Mode gold';
        localStorage.setItem('theme', 'dark'); 
    }
    else{
      button.textContent= 'Mode bleu'; 
      localStorage.setItem('theme', 'light');
    }
});