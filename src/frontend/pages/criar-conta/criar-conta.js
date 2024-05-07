function toggleForm(form, button){
    document.getElementById("client-form").style.display = "none";
    document.getElementById("barber-form").style.display = "none";
    document.getElementById(form).style.display = "block";
    document.getElementById(button).style.background = "var(--background-color-03)";
    document.getElementById(button).style.color = "var(--text-color-02)";

    if(form == "barber-form"){
        document.getElementById("first").style.background = "#232129";
        document.getElementById("first").style.color = "#666660";
    }else{
        document.getElementById("second").style.background = "#232129";
        document.getElementById("second").style.color = "#666660";
    }
}