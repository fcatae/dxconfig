"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
Object.defineProperty(exports, "__esModule", { value: true });
const request = require("request-promise");
function getAsync(endpoint, jwtToken, parameters) {
    var options = {
        auth: { bearer: jwtToken },
        qs: parameters
    };
    return request.get(endpoint, options);
}
exports.getAsync = getAsync;
function postAsync(endpoint, jwtToken, parameters) {
    return __awaiter(this, void 0, void 0, function* () {
        var options = {
            auth: { bearer: jwtToken },
            json: parameters
        };
        return request.post(endpoint, options);
    });
}
exports.postAsync = postAsync;
