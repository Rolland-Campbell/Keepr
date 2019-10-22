<template>
  <div id="app">
    <div class="row">
      <div class="col-12">
        <h1>
          KEEPR
          <img alt="Vue logo" src="./assets/logo.png" />AULT 9000
        </h1>
      </div>
    </div>
    <div id="nav">
      <router-link to="/">Home</router-link>
    </div>
    <router-view />
  </div>
</template>

<style>
#app {
  font-family: "Avenir", Helvetica, Arial, sans-serif;
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
img {
  height: 80px;
  width: 80px;
}
</style>