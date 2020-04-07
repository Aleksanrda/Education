<template>
  <v-container
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col
            cols="12"
            sm="8"
            md="4"
          >
            <v-card class="elevation-12">
              <v-toolbar
                color="primary"
                dark
                flat
              >
                <v-toolbar-title>Signup form</v-toolbar-title>
                <v-spacer />
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field
                    id="username"
                    label="Name"
                    name="name"
                    type="text"
                  />

                  <v-text-field
                    label="Phone"
                    name="phone"
                    type="tel"
                  />
                  <v-text-field
                    label="Email"
                    name="email"
                    type="email" required
                  />
                  <v-text-field
                    id="password"
                    label="Password"
                    name="password"
                    type="password" required
                  />
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer />
                <v-btn color="primary">Sign up</v-btn>
                <v-btn v-on:click="cancel">Cancel</v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
</template>

<script>
export default {
data(){
  return {
    user: {
      email: '',
      name: '',
      phoneNumber: '',
      password: ''
    },
    submitted: false
  }
},

};
</script>

<style>

</style>