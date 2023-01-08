import CompoundedSpace from "antd/es/space";
import axios, { AxiosInstance } from "axios";
import { useNavigate } from "react-router-dom";

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

instance.interceptors.response.use((response) => {
    const {status, data} = response;
    if(status === 200) return response;
    if(status === 401) Promise.reject(data);
    return Promise.reject(data);
}, error => {
    Promise.reject(error)
})

export default instance;