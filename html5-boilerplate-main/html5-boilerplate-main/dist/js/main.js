   let darkMode = false;
    document.getElementById("toggleTheme").addEventListener('click', ()=>{

    darkMode = !darkMode;
    if(darkMode){
        setSecondTheme();
    }
    else{
        setFirstTheme();
    }
});


function setFirstTheme(){

   document.body.style.backgroundColor = "#64A19A";
   document.body.style.color = "#2A253C";

   document.querySelectorAll("button").forEach(btn =>{
   btn.style.backgroundColor= "#9BD0D4";
   btn.style.color= "#9E425F";
   btn.style.padding = "10px";
   btn.style.border = "1px solid #2A253C";
   btn.style.borderRadius= "15px";
   btn.style.cursor = "pointer";
   btn.style.fontSize= "16px";
   btn.style.fontWeight= "bold";
   });
};

function setSecondTheme(){

    document.body.style.backgroundColor = "#b65d55ff";
    document.body.style.color = "#27233A";

    document.querySelectorAll("button").forEach(btn =>{
   btn.style.backgroundColor= "#88D498";
   btn.style.color= "#4281A4";
   btn.style.padding = "10px";
   btn.style.border = "1px solid #27233A";
   btn.style.borderRadius= "15px";
   btn.style.cursor = "pointer";
   btn.style.fontSize= "16px";
   btn.style.fontWeight= "bold";
    });
};

setFirstTheme();
