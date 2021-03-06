import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/User Entry',
    name: 'User Entry',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/UserEntry.vue')
  },
  {
    path: '/Skill Entry',
    name: 'Skill Entry',
    component: () => import('../views/SkillEntry.vue')
  },
  {
    path: '/User View',
    name: 'User View',
    component: () => import('../views/UserView.vue')
  }
]

const router = new VueRouter({
  routes
})

export default router
