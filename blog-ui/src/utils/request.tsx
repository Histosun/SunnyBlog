import axios, { AxiosInstance } from "axios";

axios.defaults.headers['Content-Type'] = 'application/json;charset=utf-8'

const instance:AxiosInstance = axios.create({
    baseURL: "https://localhost:8080",
    timeout: 10000
})

instance.interceptors.request.use((config) => {
    return config;
}, error => {
    Promise.reject(error)
})

export default instance;