import request from '../utils/request'

const hotArticleList = ()=>{
    return request({
        url: `/Article/GetHotArticles`,
        method: "get",
        headers: {
            isToker: false
        }
    })
}

export default hotArticleList;