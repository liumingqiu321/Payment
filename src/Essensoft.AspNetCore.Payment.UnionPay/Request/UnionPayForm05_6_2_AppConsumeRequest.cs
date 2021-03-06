﻿using System.Collections.Generic;
using Essensoft.AspNetCore.Payment.UnionPay.Response;

namespace Essensoft.AspNetCore.Payment.UnionPay.Request
{
    /// <summary>
    /// 二维码消费（被扫）
    /// </summary>
    public class UnionPayForm05_6_2_AppConsumeRequest : IUnionPayRequest<UnionPayForm05_6_2_AppConsumeResponse>
    {
        /// <summary>
        /// C2B码
        /// </summary>
        public string QrNo { get; set; }

        /// <summary>
        /// 订单发送时间
        /// 商户发送交易时间
        /// </summary>
        public string TxnTime { get; set; }

        /// <summary>
        /// 后台通知地址
        /// 后台返回商户结果时使用，如上送，则发送商户后台交易结果通知,如需通过专线通知，需要在通知地址前面加上前缀：专线的首字母加竖线ZX|
        /// </summary>
        public string BackUrl { get; set; }

        /// <summary>
        /// 交易币种
        /// 默认为156
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 交易金额
        /// 单位为分
        /// </summary>
        public string TxnAmt { get; set; }

        /// <summary>
        /// 商户订单号
        /// 商户端生成
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 二级商户代码
        /// 商户类型为平台类商户接入时必须上送
        /// </summary>
        public string SubMerId { get; set; }

        /// <summary>
        /// 二级商户简称
        /// 商户类型为平台类商户接入时必须上送
        /// </summary>
        public string SubMerAbbr { get; set; }

        /// <summary>
        /// 二级商户名称
        /// 商户类型为平台类商户接入时必须上送
        /// </summary>
        public string SubMerName { get; set; }

        /// <summary>
        /// 接入机构代码
        /// 接入机构接入时必送
        /// </summary>
        public string AccInsCode { get; set; }

        /// <summary>
        /// 保留域
        /// </summary>
        public string Reserved { get; set; }

        /// <summary>
        /// 分账域
        /// </summary>
        public string AccSplitData { get; set; }

        /// <summary>
        /// 风控信息域
        /// </summary>
        public string RiskRateInfo { get; set; }

        /// <summary>
        /// 请求方保留域
        /// 商户自定义保留域，交易应答时会原样返回
        /// </summary>
        public string ReqReserved { get; set; }

        /// <summary>
        /// 终端号
        /// 原则是可以通过交易上送的终端编号准确定位商户每一个门店内每一台收银设备，建议按“门店编号+收银机编号”或“设备编号”组成8位终端编号在交易中上送。商户需将终端编号与门店对应关系反馈给银联。
        /// </summary>
        public string TermId { get; set; }

        /// <summary>
        /// 终端信息	
        /// </summary>
        public string TermInfo { get; set; }

        #region IUnionPayRequest
        private string version = string.Empty;
        private string txnType = "01";
        private string txnSubType = "06";
        private string bizType = "000000";
        private string channelType = "07";

        public string GetApiVersion()
        {
            return version;
        }

        public void SetApiVersion(string version)
        {
            this.version = version;
        }

        public string GetTxnType()
        {
            return txnType;
        }

        public void SetTxnType(string txnType)
        {
            this.txnType = txnType;
        }


        public string GetTxnSubType()
        {
            return txnSubType;
        }

        public void SetTxnSubType(string txnSubType)
        {
            this.txnSubType = txnSubType;
        }

        public string GetBizType()
        {
            return bizType;
        }

        public void SetBizType(string bizType)
        {
            this.bizType = bizType;
        }

        public string GetChannelType()
        {
            return channelType;
        }

        public void SetChannelType(string channelType)
        {
            this.channelType = channelType;
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new UnionPayDictionary
            {
                { "qrNo", QrNo },
                { "txnTime", TxnTime },
                { "backUrl", BackUrl },
                { "currencyCode", CurrencyCode },
                { "orderId", OrderId },
                { "termInfo", TermInfo },
                { "subMerId", SubMerId },
                { "subMerAbbr", SubMerAbbr },
                { "subMerName", SubMerName },
                { "accSplitData", AccSplitData },
                { "accInsCode", AccInsCode },
                { "reserved", Reserved },
                { "txnAmt", TxnAmt },
                { "riskRateInfo", RiskRateInfo },
                { "reqReserved", ReqReserved },
                { "termId", TermId },
            };
            return parameters;
        }

        public string GetRequestUrl(bool isTest)
        {
            return isTest ? "https://gateway.test.95516.com/gateway/api/backTransReq.do" : "https://gateway.95516.com/gateway/api/backTransReq.do";
        }

        #endregion
    }
}
