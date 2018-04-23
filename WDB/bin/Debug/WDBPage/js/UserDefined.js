var Up = false;
function handsUp(event) {
	if(Up!=true)
	{document.getElementById("robo").src = "./img/robot2.png";		
		Up = true;
	}
	else
	{document.getElementById("robo").src="./img/robot1.png";
		Up =false;
	}
}