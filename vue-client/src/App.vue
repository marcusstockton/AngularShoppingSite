<template>
	<div id="app">
		<nav class="navbar navbar-expand-md bg-dark navbar-dark sticky-top">
			<router-link to="/" class="navbar-brand"><img alt="Vue logo" src="./assets/logo.png" height="25"> EBay Ripoff</router-link>
			<button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navb" aria-expanded="true">
			<span class="navbar-toggler-icon"></span>
			</button>
			<div id="navb" class="navbar-collapse collapse hide">
				<ul class="navbar-nav">
					<li class="nav-item active">
						<router-link to="/" class="nav-link">Home</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/items" class="nav-link">Items</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/about" class="nav-link">About</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/item-condition" class="nav-link">Item Conditions</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/item-category" class="nav-link">Item Category</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/delivery-option" class="nav-link">Delivery Options</router-link>
					</li>
				</ul>
				<ul class="nav navbar-nav ml-auto">
					<li class="nav-item">
						<router-link to="/register" class="nav-link">Register</router-link>
					</li>
					<li class="nav-item">
						<router-link to="/login" class="nav-link">Log In</router-link>
					</li>
				</ul>
			</div>
		</nav>
		<span class="container">
			<router-view/>
		</span>
	</div>
</template>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
#nav {
  padding: 30px;
}

#nav a {
  font-weight: bold;
  color: #2c3e50;
}

#nav a.router-link-exact-active {
  color: #42b983;
}
</style>
