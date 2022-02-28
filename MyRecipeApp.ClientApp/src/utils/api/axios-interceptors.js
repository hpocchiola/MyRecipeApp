import axios from "axios";

export const initializeInterceptors = () => {
  axios.interceptors.request.use(
    (config) => {
      // Do something before request is sent
      return config;
    },
    (error) => {
      // Do something with request error
      console.log(error);
      return Promise.reject(error);
    }
  );

  axios.interceptors.response.use(
    (response) => {
      // Any status code that lie within the range of 2xx cause this function to trigger
      // Do something with response data
      console.log(response);
      return response;
    },
    (error) => {
      // Any status codes that falls outside the range of 2xx cause this function to trigger
      // Do something with response error
      console.log(error);
      return Promise.reject(error);
    }
  );
};
