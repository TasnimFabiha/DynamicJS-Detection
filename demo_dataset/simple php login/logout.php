<?php 
	
	session_start();

	if(session_status()!=NULL){
		session_destroy();
		header("Location: login.html");
	}

 ?>