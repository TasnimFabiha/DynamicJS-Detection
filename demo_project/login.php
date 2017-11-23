<?php include "header.php";?>

<section id="login_bg">
<div  class="container">
<div class="row">
	<div class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
		<div id="login">
			
			<?php
			if(isset($_SESSION['response'])){
				if($_SESSION['responseType']=="success"){
					echo "<div class='text-center text text-success'><strong>".$_SESSION['response']."</strong></div>";
				}elseif($_SESSION['responseType']=="error"){
					echo "<div class='text-center text text-danger'><strong>".$_SESSION['response']."</strong></div>";
				}
			}
			$_SESSION['response']="";
			$_SESSION['responseType']="";


			?>

			<form action="./login.php" method="post">

				<input name="login" type="hidden" class=" form-control " value="1">
       
				<div class="form-group">
					<input name="username" type="text" class=" form-control " placeholder="Username">
					<span class="input-icon"><i class=" icon-user"></i></span>
				</div>
				<div class="form-group" style="margin-bottom:5px;">
					<input type="password" name="password" class=" form-control" placeholder="Password" style="margin-bottom:5px;">
					<span class="input-icon"><i class="icon-lock"></i></span>
				</div>

				<button type="submit" class="button_fullwidth">Log in</button>
				<a href="./register.php" class="button_fullwidth-2">Register</a>
			</form>
		</div>
	</div>
</div>
</div>
</section> <!-- End login -->
<?php include "footer.php";?>