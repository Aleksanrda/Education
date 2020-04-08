<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="6">
        <v-card class="elevation-12">
          <v-toolbar color="primary" dark flat>
            <v-toolbar-title>Signup form</v-toolbar-title>
            <v-spacer />
          </v-toolbar>
          <v-card-text>
            <v-alert :value="error" type="warning">
              {{ error }}
            </v-alert>
            <v-form>
              <v-text-field
                id="username"
                label="Name"
                name="username"
                type="text"
                required
                v-model="username"
              />

              <v-text-field
                label="Phone"
                name="tel"
                type="text"
                required
                v-model="tel"
              />
              <v-text-field
                label="Email"
                name="email"
                type="email"
                required
                v-model="email"
              />
              <v-text-field
                id="password"
                label="Password"
                name="password"
                type="password"
                required
                v-model="password"
              />
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn
              color="primary"
              @click.prevent="signup"
              :disabled="processing"
              >Sign up</v-btn
            >
            
            <router-link to="/login" class="btn btn-link"><v-btn>Cancel</v-btn></router-link>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  data() {
    return {
      email: "",
      username: "",
      tel: "",
      password: "",
    };
  },
  computed: {
    error() {
      return this.$store.getters.getError;
    },
    processing() {
      return this.$store.getters.getProcessing;
    },
    isUserAuthenticated() {
      return this.$store.getters.isUserAuthenticated;
    },
  },
  watch: {
    isUserAuthenticated(val) {
      if (val) {
        this.$router.push("/");
      }
    },
  },
  methods: {
    signup() {
      this.$store.dispatch("signup", {
        email: this.email,
        password: this.password,
        tel: parseInt(this.tel),
        username: this.username,
      });
    },
  },
};
</script>

<style></style>
