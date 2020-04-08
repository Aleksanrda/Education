import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '@/views/Home'
import Login from '@/views/Login'
import Signup from '@/views/Signup'
import Profile from '@/views/Profile'
import About from '@/views/About'
import Baby from '@/views/Baby'
import Logout from '@/views/Logout'

Vue.use(VueRouter)

const routes = [
 {
   path: '/',
   name: 'Home',
   component: Home
 },
 {
 path: '/login',
 name: 'Login',
 component: Login
 },
 {
  path: '/about',
  name: 'About',
  component: About
 },
 {
  path: '/profile',
  name: 'Profile',
  component: Profile
 },
 {
  path: '/signup',
  name: 'Signup',
  component: Signup
 },
 {
  path: '/baby',
  name: 'Baby',
  component: Baby
 },
 {
  path: '/logout',
  name: 'Logout',
  component: Logout
 },
 {
   path: '*',
   redirect: '/'
 }
]

const router = new VueRouter({
  routes
})

export default router
