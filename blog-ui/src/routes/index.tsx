import { RouteObject } from "react-router-dom";
import ArticleHome from "../pages/article/ArticleHome";
import ArticleDetail from "../pages/article/ArticleDetail";
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

] as RouteObject[]