import { RouteObject, Navigate } from "react-router-dom";
import ArticleHome from "../pages/article/ArticleHome";
import ArticleDetail from "../pages/article/ArticleDetail";
import Login from "../pages/Login";

export default [
    {
        path: '/',
        element: <ArticleHome/>
    },
    {
        path: '/Home',
        element: <ArticleHome/>
    },
    {
        path: '/Article/:id',
        element: <ArticleDetail/>
    },
    {
        path: '/Login',
        element: <Login/>
    }
] as RouteObject[]