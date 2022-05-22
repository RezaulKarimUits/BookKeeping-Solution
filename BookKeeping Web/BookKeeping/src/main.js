import { createApp } from 'vue'
import App from './App.vue'
import Toaster from '@meforma/vue-toaster';
import 'bootstrap'
import axios from 'axios';


createApp(App).use(Toaster).mount('#app')