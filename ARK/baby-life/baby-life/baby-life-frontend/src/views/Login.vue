<template>
   <v-container>
     <v-layout row wrap>
         <v-flex xs12>
             <h2>{{$t('login')}}</h2>
         </v-flex>
         <v-spacer></v-spacer>
        <v-flex xs12 sm6 offset-sm3>
            <v-text-field
            label="E-mail"
            v-model="email"
            v-bind:rules="emailRules"
            required>
            </v-text-field>
        </v-flex>
            <v-flex xs12 sm6 offset-sm3>
            <v-text-field
            label="Password"
            v-model="password"
            v-bind:rules="passwordRules"
            v-bind:type="'password'"
            required>
            </v-text-field>
        </v-flex>
        <v-flex>
            <v-btn v-on:click="cancel">Cancel</v-btn>
            <v-btn color="primary" v-on:click="login">Login</v-btn>
        </v-flex>
     </v-layout>
    <v-snackbar
        :timeout="6000"
        :top="true"
        v-model="showAlert"
    >
    {{ loginError }}
    </v-snackbar>
  </v-container>
</template>

<script>
debugger;
export default {
    data() {
        return {
            showAlert: false,
            message: '',
            email: '',
            emailRules: [
                v => !!v || 'E-mail is required',
                v => /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) || 'E-mail must be valid'
            ],
            password: '',
            passwordRules: [
                v => !!v || 'Password is required'
            ]
        }
    },
    methods: {
        login: function() {
            const vm = this
            const payload = {
                email: this.email,
                password: this.password
            }
            console.log(payload);
            this.$store.dispatch('logInUser', payload)
            .then(() => {
                if(vm.isLoggedIn) {
                    this.$router.push({ path: '/Profile'})
                } else {
                    vm.showAlert = true
                }
            })
        },
        cancel: function () {
            console.log('The user does not want to login!')
        }
    },
    computed: {
        isLoggedIn () {
            return this.$store.getters.isLoggedIn
        },
        loginError () {
            return this.$store.getters.loginError
        }
    }
}
</script>

<style>

</style>