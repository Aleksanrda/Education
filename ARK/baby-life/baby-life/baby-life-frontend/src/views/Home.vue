<template>
  <div></div>
</template>

<script>
export default {
computed: {
    isLoggedIn () {
        return this.$store.getters.isLoggedIn
    }
},
methods: {
    mounted: function () {
        console.log('Is user logged in?', this.isLoggedIn)
        if (!this.isLoggedIn) {
            this.$router.push({path: '/login'})
        }
    }
}
}
</script>

<style>

</style>