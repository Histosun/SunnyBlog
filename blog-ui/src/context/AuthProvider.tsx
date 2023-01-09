import { ReactNode, useContext, useReducer } from "react";
import AuthContext, { User, Action } from "./AuthContext";

type AuthProviderProps = {
    children: ReactNode;
};

export const AuthProvider = ({ children }: AuthProviderProps) => {
    const localUser = localStorage.getItem('user')
    const initUser : User|null = localUser ? JSON.parse(localUser) : null;

    const reducer = (user: User | null, action: Action): User|null => {
        switch(action.type){
            case 'login':
                localStorage.setItem('user', JSON.stringify(action.payload))
                return action.payload;
            case 'logout':
                localStorage.removeItem('user')
                return null;
        }
        return user;
    };

    const [user, dispatch] = useReducer(reducer, initUser);

    const value = {
        user,
        dispatch
    }
    return (
        <AuthContext.Provider value={value}>
            {children}
        </AuthContext.Provider>
    );
}