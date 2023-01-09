import { AxiosResponse } from 'axios'
import request from '../utils/request'
import { User } from '../context/AuthContext'

interface LoginRequest{
    username: string,
    password: string
};

export const login = (loginRequest: LoginRequest)=>{
    return request<any, AxiosResponse<User , any>, LoginRequest>({
        url: `/Login/LoginByUsernamePassword`,
        method: "post",
        headers: {
            isToken: false
        },
        data: loginRequest
    })
}