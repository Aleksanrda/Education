<template>
    <div>
      <v-card
      color="grey lighten-4"
      flat
      tile
    >
    <v-navigation-drawer 
    v-model="drawer"
      :clipped="$vuetify.breakpoint.lgAndUp"
      app>
           <v-list dense>
        <template v-for="item in items">
          <v-row
            v-if="item.heading"
            :key="item.heading"
            align="center"
          >
            <v-col cols="6">
              <v-subheader v-if="item.heading">
                {{ item.heading }}
              </v-subheader>
            </v-col>
            <v-col
              cols="6"
              class="text-center"
            >
              <a
                href="#!"
                class="body-2 black--text"
              >EDIT</a>
            </v-col>
          </v-row>
          <v-list-group
            v-else-if="item.children"
            :key="item.text"
            v-model="item.model"
            :prepend-icon="item.model ? item.icon : item['icon-alt']"
            append-icon=""
          >
            <template v-slot:activator>
              <v-list-item-content>
                <v-list-item-title>
                  {{ item.text }}
                </v-list-item-title>
              </v-list-item-content>
            </template>
            <v-list-item
              v-for="(child, i) in item.children"
              :key="i"
              link
            >
              <v-list-item-action v-if="child.icon">
                <v-icon>{{ child.icon }}</v-icon>
              </v-list-item-action>
              <v-list-item-content>
                <v-list-item-title>
                  {{ child.text }}
                </v-list-item-title>
              </v-list-item-content>
            </v-list-item>
          </v-list-group>
          <v-list-item
            v-else
            :key="item.text"
            link
          >
            <v-list-item-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title>
                {{ item.text }}
              </v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </template>
      </v-list>
    </v-navigation-drawer>
    
     <v-app-bar
      :clipped-left="$vuetify.breakpoint.lgAndUp"
      app
      color="blue darken-3"
      dark
    >
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        <router-link to="/" tag="span" style="cursor:pointer">
     <v-toolbar-title v-text="$t('login')"></v-toolbar-title>
     </router-link>
     <v-spacer></v-spacer>
     <v-toolbar-items>
       <div class="switch">
         <label>
           English
           <input type="checkbox">
           <span class="lever"></span>
           Український
         </label>
       </div>
       <a href="#" @click="setLocale('en')">
        English
      </a>
      <a href="#" @click="setLocale('uk')">
        Ukrain
      </a>
       <v-btn color="blue" v-for="(item, i) in menuItems" :key="`menuitem${i}`" :to="item.route"> 
         <!-- <v-icon left v-html="item.icon"></v-icon> -->
         {{item.title}}
          </v-btn>
     </v-toolbar-items>
      </v-app-bar>
      </v-card>
      </div>
</template>

<script>
export default {
     props: {
      source: String,
    },
    data: () => ({
      dialog: false,
      drawer: null,
      items: [
        { icon: 'mdi-contacts', text: 'Add Baby' },
        { icon: 'mdi-history', text: 'Current Day' },
        { icon: 'mdi-content-copy', text: 'Notes' },
        { icon: 'mdi-settings', text: 'Settings' },
        { icon: 'mdi-message', text: 'Send feedback' },
        { icon: 'mdi-help-circle', text: 'Help' },
      ],
    }),
    methods: {
        menuAction: function() {

        },
        showProfile: function() {
            console.log('show profile clicked!')
        },
        setLocale(locale) {
           import(`../langs/${locale}.json`).then((msgs) => {
             this.$i18n.setLocaleMessage(locale, msgs)
             this.$i18n.locale = locale
           })
  }
},
  computed: {
    menuItems() {
      return [
        {
          icon: 'visibility',
          title: 'Babies',
          route: '/Baby'
        },
        {
          icon: 'account_circle',
          title: 'My profile',
          route: '/Profile'
        },
        {
          icon: 'exit_to_app',
          title: 'Logout',
          route: '/logout'
        },
        {
          icon: 'input',
          title: 'login',
          route: '/Login'
        },
        {
          icon: 'lock_open',
          title: 'Sign Up',
          route: '/signup'
        }
      ]
    }
  }
}
</script>