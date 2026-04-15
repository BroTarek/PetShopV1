import React from 'react'

const CommunitySection = () => {
  return (
    <section className="bg-surface-container rounded-lg px-6 md:px-12 py-32 overflow-hidden">
            <div className="max-w-screen-2xl mx-auto flex flex-col md:flex-row gap-20 items-center">
                <div className="w-full md:w-1/2 grid grid-cols-2 gap-4">
                    <div className="space-y-4">
                        <img alt="Happy pet owner 1" className="w-full aspect-[3/4] object-cover rounded-lg"
                            data-alt="Portrait of a young man smiling and holding his small brown dog in a city park at golden hour"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuAXqzeNNLZqzMMYQBBuwLAvoxvJTlJAonCwjiDihnQZwOtpOz-AHJO_fPHUgToCZN03z3mu1rZ67r5570SlJqigLRo8_bIMB3-jBJMjLHtKVZhz-PDHZn69EKA4U_tlgfeDBW_cIZKUq0yFhOUdYu6EYcAOkxLO0Ac7Ue-D8mLa7KUM9b_rPk9py2IdnPjaXzQaRuSqvsFsq1PGqy9OuSKrt7wLElcj8kR0MT4LTYQtDQ7i-ttYpmc-nOKpQS5wX_7Dc_v82GaR5Ug" />
                        <img alt="Happy pet owner 2" className="w-full aspect-square object-cover rounded-lg"
                            data-alt="Close-up of a woman hugging her large fluffy white dog in a sunlit garden with flowers"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuD5XshYBYRz65hRO9Pgtxh17MR5Hvr6MW4-zrHPScRd3PsIxDCXYuMrROrcOX7GvsunCvY_f_ROFte99GAgyJOfRXtiLzjC31GXVZWYXkBVsCLfv33aOpPZKXqni86OK3NYytXNTpKLZbWt-Ybpn_4SrGOPcUec0GX0m35qeblhz881CqW_l5iPaSPiqT-0Q5vm9XQ4k5umI6UfEEneqSwUmUn9MzProXZU63B6AfPkppn3otWsJF_1nfYZ1E1FKYeLtjthgvmBXrI" />
                    </div>
                    <div className="space-y-4 pt-12">
                        <img alt="Happy pet owner 3" className="w-full aspect-square object-cover rounded-lg"
                            data-alt="Golden Retriever puppy sitting on a wooden porch looking curious with bright eyes"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuAsRUxu6jIu9CbqNkc9fbxkYTH4H1fYpU8cgeQ7FptBLOdIhCkqHb1Dx8hZxfQRpdouJEJRzIausKWeAnRCFjyssHJRfOt3UfKfDxOLNKo2OY2Rx-eANVmXFnqP0sWpSe-vxqfoE6068pZR0tf1bhDTSiFiHFVZoRM3-G38DNfhoMkUGTYB3gOlleRk-BMnv2_94a_IRYo5wl-wrj_dC5lj-WQFHJfEbiiTazogtIRRNrQ2wzgi3-Fo1Oov4qlGsTxVNtcxp6TA4iU" />
                        <img alt="Happy pet owner 4" className="w-full aspect-[3/4] object-cover rounded-lg"
                            data-alt="Two happy dogs of different breeds playing together in a grassy field under a soft blue sky"
                            src="https://lh3.googleusercontent.com/aida-public/AB6AXuAlDnhh4BUsWwh3ybeCe-NGeJ1kkPocEpQUNcjqXtsvymMsE971sPe9BpA9y9KdBrfJBLAeqydEChIUJ-hZo82iQrR5wHK2ivBSyGAvaNxNHVqSvyQhAt0xR_YDXfvp5ltiwqfpTeFXIYjbQ7Dd8Ap7stfycqvDVToPtegcMphwKcvLWFYAaeBRLK7QxY0Idxpyc0-ENFw40aVavy-jbudZcb0gx28dO7YXcJTKf6XkW94SHiDVGdn0mnasgYGA6cr3-5XKnLe_Fpk" />
                    </div>
                </div>
                <div className="w-full md:w-1/2">
                    <h2 className="text-4xl md:text-5xl font-extrabold tracking-tight mb-12">Loved by the most discerning
                        companions.</h2>
                    <div className="space-y-12">
                        <div
                            className="p-8 bg-surface-container-lowest rounded-lg shadow-sm border-l-4 border-secondary-fixed">
                            <p className="text-xl italic leading-relaxed text-on-surface-variant mb-6">"Finding a shop that
                                understands both my aesthetic and my dog's needs was impossible until I found The
                                Curated Companion. The quality is simply unmatched."</p>
                            <div className="flex items-center gap-4">
                                <div
                                    className="w-10 h-10 rounded-full bg-primary flex items-center justify-center text-on-primary font-bold">
                                    M</div>
                                <div>
                                    <p className="font-bold">Marcus Chen</p>
                                    <p className="text-xs text-on-surface-variant">Owner of Baxter</p>
                                </div>
                            </div>
                        </div>
                        <div className="p-8 bg-surface-container-lowest rounded-lg shadow-sm">
                            <p className="text-xl italic leading-relaxed text-on-surface-variant mb-6">"The adoption process
                                was so thoughtful. They really took the time to ensure Cooper was the right fit for our
                                family. Highly recommended."</p>
                            <div className="flex items-center gap-4">
                                <div
                                    className="w-10 h-10 rounded-full bg-secondary-fixed flex items-center justify-center text-on-secondary-fixed font-bold">
                                    A</div>
                                <div>
                                    <p className="font-bold">Aria Thompson</p>
                                    <p className="text-xs text-on-surface-variant">Owner of Cooper</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
  )
}

export default CommunitySection