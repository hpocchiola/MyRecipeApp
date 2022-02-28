import axios from "axios";

const API_URL = process.env.REACT_APP_API_URL;

export const get = (path) => {
  return axios.get(API_URL + path);
};

export const getById = (path, id) => {
  return axios.get(API_URL + path + "/" + id);
};

export const post = (path, data) => {
  return axios.post(`${API_URL}${path}`, data);
};
