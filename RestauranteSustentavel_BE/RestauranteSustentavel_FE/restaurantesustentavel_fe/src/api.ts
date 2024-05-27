import axios from 'axios'



const apiUrl = 'https://localhost:7163'


const api = axios.create({
    baseURL: apiUrl
})



export default api