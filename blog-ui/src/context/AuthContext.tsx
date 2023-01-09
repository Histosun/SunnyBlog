import { createContext, Dispatch } from 'react';

export interface User {
    userName: string;
    token: string;
}

export interface Action {
    type: string;
    payload: User;
}

type AuthContextProps = {
    user: User | null,
    dispatch: Dispatch<Action>
}

const AuthContext = createContext<AuthContextProps>({
    user: null,
    dispatch: (action: Action) => {}
});

export default AuthContext;