
  let darkMode = false;
///gestion du bouton 

document.getElementById("toggleTheme").addEventListener('click', ()=>{
   
   darkMode = !darkMode; 
   if(darkMode){
       setSecondTheme(); 
   }
   else{
       setFirstTheme(); 
   }
});

//appliquer le premier theme: 
function setFirstTheme(){
 document.body.style.backgroundColor = "#64A19A"; 
  document.body.style.color = "#2A253C";
  document.querySelectorAll("button").forEach(btn =>{
  btn.style.backgroundColor= "#9BD0D4";
  btn.style.color= "#9E425F"; 
  btn.style.padding = "#20px"; 
  btn.style.border = "1px solid #2A253C"; 
  btn.style.borderRadius= "8px"; 
  btn.style.cursor = "pointer"; 
  }); 
};

function setSecondTheme(){ 
   document.body.style.backgroundColor = "#77221aff"; 
   document.body.style.color = "#27233A"; 
   document.querySelectorAll("button").forEach(btn =>{
  btn.style.backgroundColor= "#88D498";
  btn.style.color= "#4281A4"; 
  btn.style.padding = "#20px"; 
  btn.style.border = "1px solid #27233A"; 
  btn.style.borderRadius= "8px"; 
  btn.style.cursor = "pointer";
   });
};
///appliquer le premier theme au chargement. 
 setFirstTheme(); 

