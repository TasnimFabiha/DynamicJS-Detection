<?php include  "header.php";?>

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

			<form action="./register.php" method="post">
				<input type="hidden" name="register" value="1"/>
				<div class="form-group">
					<input name="username" type="text" class=" form-control required"  placeholder="Username">
					<span class="input-icon"><i class=" icon-user"></i></span>
				</div>
				<div class="form-group">
					<input name="email" type="text" class=" form-control required" placeholder="Email">
					<span class="input-icon"><i class="icon-email"></i></span>
				</div>
				<div class="form-group">
					<input name="password" type="password" class=" form-control required" id="password1" placeholder="Password">
					<span class="input-icon"><i class=" icon-lock"></i></span>
				</div>
				<div class="form-group">
					<input name="passwordConfirm" type="password" class=" form-control required" id="password2" placeholder="Confirm password">
					<span class="input-icon"><i class=" icon-lock"></i></span>
				</div>
				<div class="form-group">
					<input name="phone" type="text" class=" form-control required"  placeholder="Phone">
					<span class="input-icon"><i class=" icon-phone"></i></span>
				</div>
                <div id="pass-info" class="clearfix"></div>
				<button class="button_fullwidth">Create an account</button>
			</form>
		</div>
	</div>
</div>
</div>
</section><!-- End register -->

<?php include  "footer.php";?>