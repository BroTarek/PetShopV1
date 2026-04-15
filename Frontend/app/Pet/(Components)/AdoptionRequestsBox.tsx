import React from 'react'

const AdoptionRequestsBox = () => {
  return (
    <>
    
                <div className="lg:col-span-4 h-full">
                    <div
                        className="bg-surface-container-low rounded-lg p-8 border border-outline-variant/10 h-full flex flex-col">
                        <div className="flex justify-between items-center mb-8">
                            <h3 className="text-2xl font-extrabold font-headline tracking-tight">Interest List</h3>
                            <span className="bg-secondary text-on-secondary px-3 py-1 rounded-full text-xs font-bold">4
                                Active</span>
                        </div>
                        <div className="space-y-6 overflow-y-auto pr-2 max-h-[400px] hide-scrollbar">
                            {/* <!-- Request 1 --> */}
                            <div
                                className="flex items-center gap-4 bg-surface-container-lowest p-4 rounded-xl border border-transparent hover:border-secondary transition-all">
                                <img alt="Avatar" className="w-12 h-12 rounded-full object-cover"
                                    src="https://lh3.googleusercontent.com/aida-public/AB6AXuD-pM_lD6jS0lU8o_p-2wJgS3-Tf4_S06ZqU_Vz0D1lZ7s_Xo-1gU6_Vv9w3lW4w4w4w4w4w4w4w4w4w4w4" />
                                <div className="flex-grow">
                                    <h4 className="font-bold text-sm">Eleanor Vance</h4>
                                    <p className="text-xs text-on-surface-variant">Requested Oct 24, 2023</p>
                                </div>
                                <div className="text-right">
                                    <p className="font-black text-secondary">0</p>
                                    <p className="text-[10px] uppercase font-bold text-on-surface-variant tracking-tighter">
                                        Pets</p>
                                </div>
                            </div>
                            {/* <!-- Request 2 --> */}
                            <div
                                className="flex items-center gap-4 bg-surface-container-lowest p-4 rounded-xl border border-transparent hover:border-secondary transition-all">
                                <img alt="Avatar" className="w-12 h-12 rounded-full object-cover"
                                    src="https://lh3.googleusercontent.com/aida-public/AB6AXuD-pM_lD6jS0lU8o_p-2wJgS3-Tf4_S06ZqU_Vz0D1lZ7s_Xo-1gU6_Vv9w3lW4w4w4w4w4w4w4w4w4w4w4" />
                                <div className="flex-grow">
                                    <h4 className="font-bold text-sm">Marcus Chen</h4>
                                    <p className="text-xs text-on-surface-variant">Requested Oct 22, 2023</p>
                                </div>
                                <div className="text-right">
                                    <p className="font-black text-secondary">2</p>
                                    <p className="text-[10px] uppercase font-bold text-on-surface-variant tracking-tighter">
                                        Pets</p>
                                </div>
                            </div>
                            {/* <!-- Request 3 --> */}
                            <div
                                className="flex items-center gap-4 bg-surface-container-lowest p-4 rounded-xl border border-transparent hover:border-secondary transition-all">
                                <img alt="Avatar" className="w-12 h-12 rounded-full object-cover"
                                    src="https://lh3.googleusercontent.com/aida-public/AB6AXuD-pM_lD6jS0lU8o_p-2wJgS3-Tf4_S06ZqU_Vz0D1lZ7s_Xo-1gU6_Vv9w3lW4w4w4w4w4w4w4w4w4w4w4" />
                                <div className="flex-grow">
                                    <h4 className="font-bold text-sm">Sarah Jenkins</h4>
                                    <p className="text-xs text-on-surface-variant">Requested Oct 20, 2023</p>
                                </div>
                                <div className="text-right">
                                    <p className="font-black text-secondary">1</p>
                                    <p className="text-[10px] uppercase font-bold text-on-surface-variant tracking-tighter">
                                        Pets</p>
                                </div>
                            </div>
                            {/* <!-- Request 4 --> */}
                            <div
                                className="flex items-center gap-4 bg-surface-container-lowest p-4 rounded-xl border border-transparent hover:border-secondary transition-all">
                                <img alt="Avatar" className="w-12 h-12 rounded-full object-cover"
                                    src="https://lh3.googleusercontent.com/aida-public/AB6AXuD-pM_lD6jS0lU8o_p-2wJgS3-Tf4_S06ZqU_Vz0D1lZ7s_Xo-1gU6_Vv9w3lW4w4w4w4w4w4w4w4w4w4w4" />
                                <div className="flex-grow">
                                    <h4 className="font-bold text-sm">The Miller Family</h4>
                                    <p className="text-xs text-on-surface-variant">Requested Oct 15, 2023</p>
                                </div>
                                <div className="text-right">
                                    <p className="font-black text-secondary">3</p>
                                    <p className="text-[10px] uppercase font-bold text-on-surface-variant tracking-tighter">
                                        Pets</p>
                                </div>
                            </div>
                        </div>
                        <button
                            className="mt-8 w-full border border-primary text-primary py-4 rounded-full font-bold text-sm font-headline hover:bg-primary hover:text-on-primary transition-all">
                            Apply for Early Consideration
                        </button>
                    </div>
                </div>
    </>
  )
}

export default AdoptionRequestsBox