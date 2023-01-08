import request from '../utils/request'

export const hotArticleList = ()=>{
    return request({
        url: `/Article/GetHotArticles`,
        method: "get",
        headers: {
            isToken: false
        }
    })
}

export const getArticleList = (pageNum: number)=>{
    return request({
        url: `/Article/GetArticleList?pageNum=${pageNum}`,
        method: "get",
        headers: {
            isToken: false
        }
    })
}

export const getArticleDetail = (articleId: string)=>{
    return request({
        url: `/Article/GetArticleDetail/${articleId}`,
        method: "get",
        headers: {
            isToken: false
        }
    })
}