import request from '../utils/request'

export const hotArticleList = ()=>{
    return request({
        url: `/Article/GetHotArticles`,
        method: "get",
        headers: {
            isToker: false
        }
    })
}

export const getArticleList = (pageNum: number)=>{
    return request({
        url: `/Article/GetArticleList?pageNum=${pageNum}`,
        method: "get",
        headers: {
            isToker: false
        }
    })
}