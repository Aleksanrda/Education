<template>
  <v-container class="fill-height" fluid>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="6">
        <v-card class="elevation-12">
          <v-toolbar color="primary" dark flat>
            <v-toolbar-title>Sign in</v-toolbar-title>
            <v-spacer />
          </v-toolbar>
          <v-card-text>
            <v-alert :value="error" type="warning">
              {{ error }}
            </v-alert>
            <v-form>
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
              @click.prevent="signin"
              :disabled="processing"
              > Sign in</v-btn
            >
            
            <router-link to="/signup" class="btn btn-link"><v-btn>Sign Up</v-btn></router-link>
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
    //   emailRules: [
    //     (v) => !!v || "E-mail is required",
    //     (v) =>
    //       /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,3})+$/.test(v) ||
    //       "E-mail must be valid",
    //   ],
      password: "",
    //   passwordRules: [(v) => !!v || "Password is required"],
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
      if (val === true) {
        this.$router.push("/Profile");
      }
    },
  },
  methods: {
    signin() {
      this.$store.dispatch("signin", {
        email: this.email,
        password: this.password
      });
    },
  },
};
</script>

<style></style>
