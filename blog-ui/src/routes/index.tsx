import { RouteObject } from "react-router-dom";
import ArticleList from "../pages/ArticleList";
import ArticleDetail from "../pages/ArticleDetail";
export default [
    {
        path: '/',
        element: <ArticleList/>
    },
    {
        path: '/Home',
        element: <ArticleList/>
    },
    {
        path: '/Article/:id',
        element: <ArticleDetail/>
    },

] as RouteObject[]