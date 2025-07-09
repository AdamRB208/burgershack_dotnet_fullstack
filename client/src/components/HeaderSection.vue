<script setup>

</script>


<template>
<div class="header-container border-bottom border-2 border-bs-orange">
          <img class="header-img"
            src="https://images.unsplash.com/photo-1609446605707-fb3732c2dbdc?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxzZWFyY2h8NXx8YnVyZ2VyJTIwc2hhY2t8ZW58MHwwfDB8fHwy"
            alt="Header image for the burger shack">
          <div class="header-text">
            <h1>SHACK</h1>
          </div>
        </div>
</template>


<style lang="scss" scoped>
.header-container {
  position: relative;
  width: 100%;
}

.header-img {
  display: block;
  width: 100%;
  max-height: 70dvh;
}

.header-text {
  position: absolute;
  bottom: 27%;
  left: 42%;
  font-weight: bold;
  font-size: xx-large;
  color: #ed9153;
  font-family: "Bungee", sans-serif;
  font-weight: 400;
  font-style: normal;
  // background: linear-gradient(#8f2e1a 40%, transparent);
  border-radius: 50px 50px 50px 50px;
  text-shadow: 0px 5px 4px #8f2e1a;
  display: flex;
  justify-content: center;
  max-height: 60dvh;
  padding: 5px;

  // transform: translate(-50%, -50%)
}
</style>